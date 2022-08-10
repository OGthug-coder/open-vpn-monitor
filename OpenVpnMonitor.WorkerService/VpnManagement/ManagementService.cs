using Microsoft.EntityFrameworkCore;
using OpenVpnMonitor.DataAccess;
using OpenVpnMonitor.DataAccess.Repositories;
using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.Domain.Repositories;
using OpenVpnMonitor.WorkerService.Infrastructure;
using OpenVpnMonitor.WorkerService.Parser;

namespace OpenVpnMonitor.WorkerService.VpnManagement;

public class ManagementService : IManagementService
{
    private readonly IManagementClient _managementClient;
    private readonly IVpnUserRepository _vpnUserRepository;
    private readonly IRecordRepository _recordRepository;

    public ManagementService(IManagementClient managementClient,
        IConfiguration configuration)
    {
        _managementClient = managementClient;

        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
        dbContextOptions.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        
        var dbContext = new ApplicationDbContext(dbContextOptions.Options);
        
        _vpnUserRepository = new VpnUserRepository(dbContext);
        _recordRepository = new RecordRepository(dbContext);
    }
    
    public async Task FetchRecords()
    {
        var records =  await _managementClient.GetRecords();

        foreach (var record in records)
        {
            var user = await _vpnUserRepository.FindUserByNameAsync(record.User.Name);

            if (user == null)
            {
                await _vpnUserRepository.CreateUserAsync(record.User);
            }
            else
            {
                record.User = user;
            }

            await _recordRepository.CreateRecordAsync(record);
        }
    }
}