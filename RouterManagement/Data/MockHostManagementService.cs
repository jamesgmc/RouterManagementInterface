using RouterManagement.Data.Models;
using RouterManagement.Services;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;

public class MockHostManagementService : IHostManagementService
{
    private readonly StatusService _statusService;

    public string StatusMessageBlue
    {
        set
        {
            _statusService.UpdateStatusMessage(value, "bg-blue-500");
        }
    }

    public string StatusMessageGreen
    {
        set
        {
            _statusService.UpdateStatusMessage(value, "bg-green-500");
        }
    }

    public MockHostManagementService(StatusService statusService)
    {
        _statusService = statusService;
    }

    public async Task<RouterHosts> GetDevicesAsync()
    {
        // Simulate reading a JSON file or return hardcoded data
        return await Task.FromResult(new RouterHosts
        {
            Success = true,
            HostList = HostList
        });
    }

    [JsonPropertyName("hosts")]
    public List<RouterHost> HostList { get; set; } = new List<RouterHost>
        {
            new RouterHost
            {
                Mac = "11:22:33:33:44:55",
                Hostname = "James-Laptop",
                IP = "192.168.1.107",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 2.4",
                Lease = "Dynamic",
                LeaseTime = "23:30:59"
            },
            new RouterHost
            {
                Mac = "AA:BB:CC:DD:EE:FF",
                Hostname = "Amys-Laptop",
                IP = "192.168.1.121",
                IsOnline = true,
                IsBlackListed = true,
                ConnectionType = "Wireless 5.0",
                Lease = "Static",
                LeaseTime = "",
                BlackListHostId = "16"
            },
            new RouterHost
            {
                Mac = "AA:11:BB:22:CC:33",
                Hostname = "Amys-Phone",
                IP = "192.168.1.109",
                IsOnline = false,
                IsBlackListed = false,
                ConnectionType = "-",
                Lease = "Dynamic",
                LeaseTime = "07:17:36"
            },
            new RouterHost
            {
                Mac = "66:77:88:99:00:11",
                Hostname = "Amys-XboxOneX",
                IP = "192.168.1.130",
                IsOnline = false,
                IsBlackListed = false,
                ConnectionType = "-",
                Lease = "Static",
                LeaseTime = ""
            },
            new RouterHost
            {
                Mac = "AA:A1:BB:B1:CC:C1",
                Hostname = "James-Phone",
                IP = "192.168.1.120",
                IsOnline = false,
                IsBlackListed = false,
                ConnectionType = "-",
                Lease = "Static",
                LeaseTime = ""
            },
            new RouterHost
            {
                Mac = "D1:DD:D2:D2:D2:D2",
                Hostname = "Games_PC",
                IP = "192.168.1.106",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wired",
                Lease = "Dynamic",
                LeaseTime = "20:30:24"
            },
            new RouterHost
            {
                Mac = "BB:CC:DD:EE:FF:55",
                Hostname = "TV_Hisense_58",
                IP = "192.168.1.181",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 5.0",
                Lease = "Static",
                LeaseTime = ""
            },
            new RouterHost
            {
                Mac = "E1:E9:C1:C9:A1:A9",
                Hostname = "TV_Hisense_42",
                IP = "192.168.1.222",
                IsOnline = false,
                IsBlackListed = true,
                ConnectionType = "-",
                Lease = "Static",
                LeaseTime = "",
                BlackListName = "James-PC_ACL",
                BlackListHostId = "143",
                BlackListRuleId = "98"
            },new RouterHost
            {
                Mac = "22:33:44:55:66:77",
                Hostname = "Office-PC",
                IP = "192.168.1.150",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wired",
                Lease = "Dynamic",
                LeaseTime = "12:15:30"
            },
            new RouterHost
            {
                Mac = "FF:EE:DD:CC:BB:AA",
                Hostname = "James-iPad",
                IP = "192.168.1.112",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 2.4",
                Lease = "Static",
                LeaseTime = ""
            },
            new RouterHost
            {
                Mac = "12:34:56:78:9A:BC",
                Hostname = "HomePod",
                IP = "192.168.1.113",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 5.0",
                Lease = "Dynamic",
                LeaseTime = "14:50:45"
            },
            new RouterHost
            {
                Mac = "DE:AD:BE:EF:00:11",
                Hostname = "James-WorkLaptop",
                IP = "192.168.1.114",
                IsOnline = false,
                IsBlackListed = true,
                ConnectionType = "-",
                Lease = "Static",
                LeaseTime = "",
                BlackListHostId = "22"
            },
            new RouterHost
            {
                Mac = "AA:BB:CC:11:22:33",
                Hostname = "SmartLight-Bedroom",
                IP = "192.168.1.117",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 2.4",
                Lease = "Dynamic",
                LeaseTime = "10:25:00"
            },
            new RouterHost
            {
                Mac = "01:23:45:67:89:AB",
                Hostname = "James-SmartWatch",
                IP = "192.168.1.118",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 5.0",
                Lease = "Dynamic",
                LeaseTime = "18:45:12"
            },
            new RouterHost
            {
                Mac = "FE:DC:BA:98:76:54",
                Hostname = "Kitchen-EchoDot",
                IP = "192.168.1.119",
                IsOnline = false,
                IsBlackListed = true,
                ConnectionType = "-",
                Lease = "Static",
                LeaseTime = "",
                BlackListHostId = "35"
            },
            new RouterHost
            {
                Mac = "11:22:33:44:55:66",
                Hostname = "James-SmartTV",
                IP = "192.168.1.110",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 5.0",
                Lease = "Static",
                LeaseTime = ""
            },
            new RouterHost
            {
                Mac = "99:88:77:66:55:44",
                Hostname = "GuestLaptop",
                IP = "192.168.1.123",
                IsOnline = false,
                IsBlackListed = false,
                ConnectionType = "-",
                Lease = "Dynamic",
                LeaseTime = "13:10:18"
            },
            new RouterHost
            {
                Mac = "0A:0B:0C:0D:0E:0F",
                Hostname = "James-SmartPlug",
                IP = "192.168.1.124",
                IsOnline = true,
                IsBlackListed = false,
                ConnectionType = "Wireless 2.4",
                Lease = "Dynamic",
                LeaseTime = "19:30:45"
            }
    };

    public async Task SetHostnameAsync(string newHostname, RouterHost host)
    {
        // Simulate success
        StatusMessageGreen = "Hostname Updated to " + newHostname;
        host.Hostname = newHostname;
        await Task.CompletedTask;
    }

    public async Task AddToBlackListAsync(RouterHost host)
    {
        // Simulate success
        StatusMessageGreen = host.Hostname + " Added to Blacklist";
        host.BlackListHostId = "123";
        host.BlackListRuleId = "456";
        await Task.CompletedTask;
    }

    public async Task RemoveFromBlackListAsync(RouterHost host)
    {
        // Simulate success
        StatusMessageBlue = host.Hostname + " Removed from Blacklist";
        host.IsBlackListed = false;
        await Task.CompletedTask;
    }

    public async Task ToggleBlackListAsync(RouterHost host)
    {


        // Simulate success
        await Task.CompletedTask;
    }

    public async Task HostPacketCountersAsync(RouterHosts hosts)
    {
        foreach (var host in hosts.HostList)
        {
            Random random = new Random();
            host.PacketCountReceived += random.Next(0, 51);
            host.PacketCountSent += random.Next(0, 51);
        }

        await Task.CompletedTask;
    }

    public async Task SetStaticHostIP(string newDhcpValue, RouterHost host)
    {
        StatusMessageBlue = "Static IP Address Updated: " + newDhcpValue;
        await Task.CompletedTask;
    }

    public async Task ToggleBlackListAsync(bool toggle)
    {
        await Task.CompletedTask;
    }
}
