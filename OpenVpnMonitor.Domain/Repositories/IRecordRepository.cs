using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.Domain.Repositories;

public interface IRecordRepository
{
    Task<Record> CreateRecordAsync(Record record);

    Task<Record> FindRecordByIdAsync(long id);

    IEnumerable<Record> FindRecords(Func<Record, bool> func);
}