namespace OpenVpnMonitor.Domain.Models;

public class Record
{
    public long Id { get; set; }
    public VpnUser User { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public long BytesReceived { get; set; }
    
    public long BytesSent { get; set; }
}