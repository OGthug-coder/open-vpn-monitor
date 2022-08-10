using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.WorkerService.VpnManagement;

public interface IManagementService
{ 
    Task FetchRecords();
}