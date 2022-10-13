using System.Globalization;

namespace OpenVpnMonitor.Domain.Models;

public class Trace
{
    public Trace(IEnumerable<Record> input)
    {
        X = input.Select(x => x.DateTime.ToString()).ToArray();
        Y = input.Select(x => x.BytesReceived).ToArray();
        Name = input.FirstOrDefault().User.Name;
    }
    
    public string[] X { get; set; }
    
    public long[] Y { get; set; }

    public string Type = "scatter";
    
    public string Name { get; set; }
}