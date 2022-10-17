using System;
using System.Linq;
using NUnit.Framework;
using OpenVpnMonitor.WorkerService.Parser;

namespace OpenVpnMonitor.Tests;

public class RecordParserTests
{
    [Test]
    public void CanParseRecord()
    {
        var recordParser = new RecordParser();

        const string input = @">INFO:OpenVPN Management Interface Version 1 -- type 'help' for more info
TITLE,OpenVPN 2.4.7 x86_64-pc-linux-gnu [SSL (OpenSSL)] [LZO] [LZ4] [EPOLL] [PKCS11] [MH/PKTINFO] [AEAD] built on Jul 19 2021
TIME,Mon Oct 17 16:05:32 2022,1666022732
HEADER,CLIENT_LIST,Common Name,Real Address,Virtual Address,Virtual IPv6 Address,Bytes Received,Bytes Sent,Connected Since,Connected Since (time_t),Username,Client ID,Peer ID
CLIENT_LIST,user_name,111.111.111.111:1111,1.1.1.1,,100,100,Mon Oct 17 00:00:01 2022,1666021778,UNDEF,888617,1
HEADER,ROUTING_TABLE,Virtual Address,Common Name,Real Address,Last Ref,Last Ref (time_t)
ROUTING_TABLE,1.1.1.1,mama-mashi,111.111.111.111:1111,Mon Oct 17 00:00:01 2022,1666022732
GLOBAL_STATS,Max bcast/mcast queue length,35
END
";

        var records = recordParser.ParseRecord(input).ToList();
        Assert.AreEqual(1, records.Count);

        var record = records.First();
        Assert.AreEqual("111.111.111.111:1111", record.IpAddress);
        Assert.AreEqual(100, record.BytesReceived);
        Assert.AreEqual(100, record.BytesSent);
        Assert.AreEqual("Mon Oct 17 00:00:01 2022", record.ConnectedSince);
        Assert.AreEqual("user_name", record.User.Name);
    }
}