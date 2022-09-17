using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.Domain.Repositories;

namespace OpenVpnMonitor.Services.VpnUserService;

public class VpnUserService : IVpnUserService
{
    private readonly IVpnUserRepository _vpnUserRepository;

    public VpnUserService(IVpnUserRepository vpnUserRepository)
    {
        _vpnUserRepository = vpnUserRepository;
    }
    
    public async Task<IEnumerable<VpnUser>> GetVpnUsersAsync()
    {
        return await _vpnUserRepository.GetUsersAsync();
    }
}