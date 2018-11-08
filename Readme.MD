# Readme

## HostInfo

Helper library for async pinging hosts by hostname, ipv4 and ipv4, also provides hostname, and other IPAdresses

### Usage

1. Create host object:
```cs
var host = new Host();
host.SetHostname("host.domain");
host.SetIPv4("10.0.0.1");
host.SetIPv4("some:ipv6:addr:esst:ring");
```

2. Check availability:
```cs
bool hostnameAvailable = await GetHostStatus.Instance.CheckHostname(host.Hostname);
bool ipv4Available = await GetHostStatus.Instance.CheckIPv4(host.IPv4);
bool ipv6Available = await GetHostStatus.Instance.CheckIPv6(host.IPv6);
```

3. Check current device data:
```cs
var localInfo = new GetLocalInfo();

string hostname = localInfo.Hostname;
List<IPAddress> ipAddresses = localInfo.IPaddresses;
```

### Other info:
GetHostStatus is a singleton, methods are asynchronus.
GetHostStatus throws ArgumentNullException if value is null;
