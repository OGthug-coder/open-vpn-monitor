namespace OpenVpnMonitor.Domain.Models.StatsModels;

public class GetStatsByPeriodRequestModel
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}