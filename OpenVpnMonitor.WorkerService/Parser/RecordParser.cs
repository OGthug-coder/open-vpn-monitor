using OpenVpnMonitor.Domain.Models;

namespace OpenVpnMonitor.WorkerService.Parser;

public class RecordParser : IRecordParser
{
    public IEnumerable<Record> ParseRecord(string rawData)
    {
        var lines = rawData.Split("\n")
            .Where(x => x != string.Empty)
            .Where(x => x.StartsWith("CLIENT_LIST"));

        var result = new List<Record>();
        
        foreach (var line in lines)
        {
            var tmp = line.Split(",");

            var userName = tmp[1];

            if (userName == "UNDEF")
            {
                break;
            }
            
            var ipAddress = tmp[2];
            var bytesReceived = Convert.ToInt64(tmp[5]);
            var bytesSent = Convert.ToInt64(tmp[6]);
            var connectedSince = tmp[7];
            var clientId = Convert.ToInt64(tmp[10]);

            var user = new VpnUser
            {
                InternalId = clientId,
                Name = userName
            };

            var record = new Record
            {
                User = user,
                IpAddress = ipAddress,
                BytesReceived = bytesReceived,
                BytesSent = bytesSent,
                ConnectedSince = connectedSince,
                DateTime = DateTime.UtcNow
            };
            
            result.Add(record);
        }
        
        return result;
    }
}