namespace OpenVpnMonitor.Metrics;

public interface IOpenVpnMonitorMetrics
{
    void BytesSent(long value, string userName);

    void BytesReceived(long value, string userName);
}