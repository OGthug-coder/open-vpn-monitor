using Prometheus;

namespace OpenVpnMonitor.Metrics;

public class OpenVpnMonitorMetrics : IOpenVpnMonitorMetrics
{
    private const string LabelName = "user_name";
    
    private const string BytesSentGaugeName = "openvpnmonitor_bytes_sent_gauge";
    private const string BytesReceivedGaugeName = "openvpnmonitor_bytes_received_gauge";
    
    private const string BytesSentGaugeHelp = "Bytes sent gauge";
    private const string BytesReceivedGaugeHelp = "Bytes received gauge";
    
    private readonly Gauge _bytesSentGauge;
    private readonly Gauge _bytesReceivedGauge;

    public OpenVpnMonitorMetrics()
    {
        _bytesSentGauge = Prometheus.Metrics
            .CreateGauge(BytesSentGaugeName, BytesSentGaugeHelp, LabelName);

        _bytesReceivedGauge = Prometheus.Metrics
            .CreateGauge(BytesReceivedGaugeName, BytesReceivedGaugeHelp, LabelName);
    }
    
    public void BytesSent(long value, string userName)
    {
        _bytesSentGauge.WithLabels(userName).Set(value);
    }

    public void BytesReceived(long value, string userName)
    {
        _bytesReceivedGauge.WithLabels(userName).Set(value);
    }
}