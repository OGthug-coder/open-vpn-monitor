namespace OpenVpnMonitor.Domain.Models.StatsModels;

public class GetStatsByPeriodResponseModel
{
    public GetStatsByPeriodResponseModel(IEnumerable<IEnumerable<Record>> input)
    {
        Traces = input.Select(x => new Trace(x));
    }
    
    public IEnumerable<Trace> Traces { get; set; }
}