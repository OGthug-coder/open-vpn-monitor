using System.Net;
using System.Net.Sockets;
using System.Text;
using OpenVpnMonitor.Domain.Models;
using OpenVpnMonitor.WorkerService.Parser;

namespace OpenVpnMonitor.WorkerService.Infrastructure;

public class ManagementClient : IManagementClient
{
    private readonly IPEndPoint _remoteEndPoint;
    private readonly IRecordParser _recordParser;
    private readonly string _hostEntry;

    public ManagementClient(IConfiguration configuration, IRecordParser recordParser)
    {
        _hostEntry = configuration["Management:Host"];
        _remoteEndPoint = new IPEndPoint(GetIpAddress(), Convert.ToInt32(configuration["Management:Port"]));
        Console.WriteLine(_hostEntry);
        Console.WriteLine(_remoteEndPoint.Address);
        Console.WriteLine(_remoteEndPoint.Port);
        _recordParser = recordParser;
    }

    private IPAddress GetIpAddress()
    {
        var ipHostInfo = Dns.GetHostEntry(_hostEntry);
        var ipAddress = ipHostInfo.AddressList[0];
        return ipAddress;
    }

    public async Task<IEnumerable<Record>> GetRecords()
    {
        const string command = "status\n";
        var response = await SendCommand(command);
        return _recordParser.ParseRecord(response); 
    }

    private async Task<string> SendCommand(string command)
    {
        try
        {
            var socket = new Socket(GetIpAddress().AddressFamily,
                SocketType.Stream, ProtocolType.Tcp );
            
            var bytes = new byte[1024];
            await socket.ConnectAsync(_remoteEndPoint);
            var message = Encoding.UTF8.GetBytes(command);
            
            socket.Send(message);

            var data = string.Empty;

            while (true)
            {
                var bytesReceived = socket.Receive(bytes);
                var line = Encoding.UTF8.GetString(bytes, 0, bytesReceived);
                data += line;

                if (data.EndsWith("\nEND\r\n"))
                {
                    break;
                }
            }
            
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            
            return data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}