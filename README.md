# OpenVPN monitor

Service for collecting and exporting VPN stats to Prometheus

## Configuration
Set OpenVPN management port, scrapping interval and host address
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Management": {
    "Port": "5555",
    "Delay": "5000",
    "Host": "localhost"
  }
}
```

## Usage

You can scrap metrics for Prometheus from `/metrics` url:
```
# HELP openvpnmonitor_bytes_received_gauge Bytes received gauge
# TYPE openvpnmonitor_bytes_received_gauge gauge
openvpnmonitor_bytes_received_gauge{user_name="User1"} 2319907
openvpnmonitor_bytes_received_gauge{user_name="User2"} 3566966
openvpnmonitor_bytes_received_gauge{user_name="User3"} 3651
openvpnmonitor_bytes_received_gauge{user_name="User4"} 304111
# HELP openvpnmonitor_bytes_sent_gauge Bytes sent gauge
# TYPE openvpnmonitor_bytes_sent_gauge gauge
openvpnmonitor_bytes_sent_gauge{user_name="User1"} 19904858
openvpnmonitor_bytes_sent_gauge{user_name="User2"} 153398417
openvpnmonitor_bytes_sent_gauge{user_name="User3"} 3842
openvpnmonitor_bytes_sent_gauge{user_name="User4"} 10946158
```

### Grafana dashboard
