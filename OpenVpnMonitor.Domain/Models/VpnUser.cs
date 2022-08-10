namespace OpenVpnMonitor.Domain.Models;

public class VpnUser
{
    public long Id { get; set; }
    
    public long InternalId { get; set; }
    
    public string Name { get; set; } = null!;
}