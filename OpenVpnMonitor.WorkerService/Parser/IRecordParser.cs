using System.Collections.Specialized;
using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.WorkerService.Parser;

public interface IRecordParser
{
    IEnumerable<Record> ParseRecord(string rawData);
}