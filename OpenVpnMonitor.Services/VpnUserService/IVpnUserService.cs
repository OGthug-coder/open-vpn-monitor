using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.Services.VpnUserService;

public interface IVpnUserService
{
    Task<IEnumerable<VpnUser>> GetVpnUsersAsync();
}