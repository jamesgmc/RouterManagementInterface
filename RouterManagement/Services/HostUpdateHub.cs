using Microsoft.AspNetCore.SignalR;
using RouterManagement.Data;
using RouterManagement.Data.Services;

namespace RouterManagement.Services;

public class HostUpdateHub : Hub
{
    private readonly IHostManagementService _hostManagementService;

    public HostUpdateHub(IHostManagementService hostManagementService)
    {
        _hostManagementService = hostManagementService;
    }

    public async Task SendHostUpdates()
    {
        var hostData = await _hostManagementService.GetDevicesAsync();
        await _hostManagementService.HostPacketCountersAsync(hostData);
        await Clients.All.SendAsync("ReceiveHostUpdates", hostData);
    }
}