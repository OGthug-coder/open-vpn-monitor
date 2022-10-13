using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.Domain.Repositories;

namespace OpenVpnMonitor.Services.StatsService;

public class StatsService : IStatsService
{
    private readonly IRecordRepository _recordRepository;

    public StatsService(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }
    
    public async Task<IEnumerable<IEnumerable<Record>>> GetStatisticsPerPeriod(DateTime @from, DateTime to)
    {
        var lol = _recordRepository.FindRecords(x => x.User.Name == "andrew").ToList();
        var result = new List<IEnumerable<Record>>();
        var records = _recordRepository.FindRecords(x => x.DateTime > from && x.DateTime <= to);
        var tmp = records.ToList();
        var groupedRecords = tmp.GroupBy(x => x.User.Id);

        foreach (var groupedRecord in groupedRecords)
        {
            result.Add(groupedRecord.ToList());
        }

        return result;
    }
}