using Microsoft.EntityFrameworkCore;
using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.Domain.Repositories;

namespace OpenVpnMonitor.DataAccess.Repositories;

public class VpnUserRepository : IVpnUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VpnUserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<VpnUser> CreateUserAsync(VpnUser user)
    {
        _dbContext.VpnUsers!.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<VpnUser> UpdateUserAsync(VpnUser user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<VpnUser> FindUserByIdAsync(long id)
    {
        return (await _dbContext.VpnUsers.FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<VpnUser> FindUserByNameAsync(string name)
    {
        return await _dbContext.VpnUsers.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<IEnumerable<VpnUser>> GetUsersAsync()
    {
        return _dbContext.VpnUsers;
    }
}