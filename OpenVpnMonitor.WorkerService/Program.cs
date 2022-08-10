using Microsoft.EntityFrameworkCore;
using OpenVpnMonitor.DataAccess;
using OpenVpnMonitor.DataAccess.Repositories;
using OpenVpnMonitor.Domain.Repositories;
using OpenVpnMonitor.WorkerService.Infrastructure;
using OpenVpnMonitor.WorkerService.Parser;
using OpenVpnMonitor.WorkerService.VpnManagement;

namespace OpenVpnMonitor.WorkerService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IRecordParser, RecordParser>();
                    services.AddTransient<IManagementClient, ManagementClient>();
                    services.AddTransient<IManagementService, ManagementService>();
                    
                    services.AddHostedService<Worker>();
                });
    }
}
