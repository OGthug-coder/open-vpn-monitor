using OpenVpnMonitor.WorkerService.VpnManagement;

namespace OpenVpnMonitor.WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IManagementService _managementService;
    private readonly int _delay;

    public Worker(ILogger<Worker> logger, IManagementService managementService, IConfiguration configuration)
    {
        _logger = logger;
        _managementService = managementService;
        _delay = Convert.ToInt32(configuration["Management:Delay"]);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _managementService.FetchRecords();
            _logger.LogInformation($"Received record at {DateTime.UtcNow}");
            await Task.Delay(_delay, stoppingToken);
        }
    }
}