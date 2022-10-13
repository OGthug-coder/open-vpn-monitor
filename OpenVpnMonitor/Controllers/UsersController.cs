using Microsoft.AspNetCore.Mvc;
using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.Services.VpnUserService;

namespace OpenVpnMonitor.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IVpnUserService _vpnUserService;

    public UsersController(IVpnUserService vpnUserService)
    {
        _vpnUserService = vpnUserService;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<IEnumerable<VpnUser>>> GetUsers()
    {
        var result = await _vpnUserService.GetVpnUsersAsync();
        return Ok(result);
    }
}