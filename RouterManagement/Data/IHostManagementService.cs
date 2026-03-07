using RouterManagement.Data.Models;


public interface IHostManagementService
{
    Task<RouterHosts> GetDevicesAsync();
    Task SetHostnameAsync(string newHostname, RouterHost host);
    Task AddToBlackListAsync(RouterHost host);
    Task RemoveFromBlackListAsync(RouterHost host);
    Task ToggleBlackListAsync(bool toggle);
    Task SetStaticHostIP(string newDhcpValue, RouterHost host);
    Task HostPacketCountersAsync(RouterHosts hosts);
}
