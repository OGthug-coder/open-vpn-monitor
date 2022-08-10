using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.WorkerService.Infrastructure;

public interface IManagementClient
{
    Task<IEnumerable<Record>> GetRecords();
}