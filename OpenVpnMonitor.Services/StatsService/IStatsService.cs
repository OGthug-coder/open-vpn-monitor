using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.Services.StatsService;

public interface IStatsService
{
    Task<IEnumerable<IEnumerable<Record>>> GetStatisticsPerPeriod(DateTime from, DateTime to);
}