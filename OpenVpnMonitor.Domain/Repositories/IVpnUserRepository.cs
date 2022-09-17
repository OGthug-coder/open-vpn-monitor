using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.Domain.Repositories;

public interface IVpnUserRepository
{
    Task<VpnUser> CreateUserAsync(VpnUser user);

    Task<VpnUser> UpdateUserAsync(VpnUser user);

    Task<VpnUser> FindUserByIdAsync(long id);

    Task<VpnUser> FindUserByNameAsync(string name);

    Task<IEnumerable<VpnUser>> GetUsersAsync();
}