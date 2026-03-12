using Microsoft.AspNetCore.SignalR;
using RouterManagement.Data.Services;

namespace RouterManagement.Services;

public class HostUpdateBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IHubContext<HostUpdateHub> _hubContext;

    public HostUpdateBackgroundService(IServiceProvider serviceProvider, IHubContext<HostUpdateHub> hubContext)
    {
        _serviceProvider = serviceProvider;
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var statusService = scope.ServiceProvider.GetRequiredService<StatusService>();
                if (statusService.IsServiceDown)
                {
                    await Task.Delay(5000, stoppingToken);
                    continue;
                }

                var hostManagementService = scope.ServiceProvider.GetRequiredService<IHostManagementService>();
                var hostData = await hostManagementService.GetDevicesAsync();
                
                if (hostData != null && !hostData.Success)
                {
                    statusService.IsServiceDown = true;
                }

                if (hostData != null && hostData.Success)
                {
                    await hostManagementService.HostPacketCountersAsync(hostData);
                }

                await _hubContext.Clients.All.SendAsync("ReceiveHostUpdates", hostData);
            }

            await Task.Delay(5000, stoppingToken);
        }
    }
}