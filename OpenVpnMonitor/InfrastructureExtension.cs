using OpenVpnMonitor.WorkerService;
using OpenVpnMonitor.WorkerService.Infrastructure;
using OpenVpnMonitor.WorkerService.Parser;
using OpenVpnMonitor.WorkerService.VpnManagement;

namespace OpenVpnMonitor;

public static class InfrastructureExtension
{
    public static void AddWorkerService(this IServiceCollection services)
    {
        services.AddTransient<IRecordParser, RecordParser>();
        services.AddTransient<IManagementClient, ManagementClient>();
        services.AddTransient<IManagementService, ManagementService>();

        services.AddHostedService<Worker>();
    }
}