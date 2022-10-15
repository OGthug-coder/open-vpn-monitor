using OpenVpnMonitor.Metrics;
using OpenVpnMonitor.WorkerService.Infrastructure;

namespace OpenVpnMonitor.WorkerService.VpnManagement;

public class ManagementService : IManagementService
{
    private readonly IManagementClient _managementClient;
    private readonly IOpenVpnMonitorMetrics _metrics;

    public ManagementService(
        IManagementClient managementClient,
        IConfiguration configuration,
        IOpenVpnMonitorMetrics metrics)
    {
        _managementClient = managementClient;
        _metrics = metrics;
    }
    
    public async Task FetchRecords()
    {
        var records =  await _managementClient.GetRecords();

        foreach (var record in records)
        {
            _metrics.BytesSent(record.BytesSent, record.User.Name);
            _metrics.BytesReceived(record.BytesReceived, record.User.Name);
        }
    }
}