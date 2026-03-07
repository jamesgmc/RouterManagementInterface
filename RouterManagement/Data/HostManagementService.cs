using RouterManagement.Data.Models;
using RouterManagement.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouterManagement.Data.Services
{
    public class HostManagementService : IHostManagementService
    {
        private readonly HttpClient _httpClient;
        private readonly StatusService _statusService;
        private readonly string _baseUrl;

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

        public string StatusMessageRed
        {
            set => _statusService.UpdateStatusMessage(value, "bg-red-500");
        }

        public HostManagementService(HttpClient httpClient, StatusService statusService, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _statusService = statusService;
            _baseUrl = configuration["ApiBaseUrl"] ?? "http://localhost:3000";
        }

        public async Task<RouterHosts> GetDevicesAsync()
        {
            try
            {
                // http://localhost:3000/api/getHosts
                var response = await _httpClient.GetFromJsonAsync<RouterHosts>($"{_baseUrl}/api/getHosts");
                if (response != null && response.Success)
                {
                    return response;
                }

                StatusMessageRed = "Error fetching device data: ";
                return new RouterHosts("Failed to retrieve Data: " + response?.Error);
            }
            catch (Exception ex)
            {
                StatusMessageRed = "Error fetching device data: ";
                return new RouterHosts("Failed to retrieve Data: " + ex.Message);
            }
        }

        public async Task SetHostnameAsync(string newHostname, RouterHost host)
        {
            try
            {
                var url = $"{_baseUrl}/api/setHostname?hostname={newHostname}&mac={host.Mac}";
                var response = await _httpClient.GetFromJsonAsync<RouterHosts>(url);

                if (response?.Success == true)
                {
                    StatusMessageGreen = "Hostname Updated to " + newHostname;
                    host.Hostname = newHostname;
                    return;
                }

                StatusMessageRed = response?.Error;
            }
            catch (Exception ex)
            {
                StatusMessageRed = "Error fetching device data: " + ex.Message;
            }
        }

        public async Task AddToBlackListAsync(RouterHost host)
        {
            try
            {
                var url = $"{_baseUrl}/api/blacklistAddHost?hostname={host.Hostname}&mac={host.Mac}";
                var response = await _httpClient.GetFromJsonAsync<AddToBlackListResponse>(url);

                if (response?.Success == true)
                {
                    host.BlackListHostId = response.BlackListHostId;
                    host.BlackListRuleId = response.BlackListRuleId;
                    StatusMessageGreen = host.Hostname + " Added to Blacklist";
                    return;
                }

                StatusMessageRed = "Error: " + response?.Error;
            }
            catch (Exception ex)
            {
                StatusMessageRed = "Error fetching device data: " + ex.Message;
            }

            host.IsBlackListed = false;  // Reset as request failed
        }

        public async Task RemoveFromBlackListAsync(RouterHost host)
        {
            try
            {
                var url = $"{_baseUrl}/api/blacklistRemoveHost?hostId={host.BlackListHostId}&ruleId={host.BlackListRuleId}";
                var response = await _httpClient.GetFromJsonAsync<RouterResponse>(url);

                if (response?.Success == true)
                {
                    StatusMessageBlue = host.Hostname + " Removed from Blacklist";
                    return;
                }

                StatusMessageRed = "Error: " + response?.Error;
            }
            catch (Exception ex)
            {
                StatusMessageRed = "Error fetching device data: " + ex.Message;
            }

            host.IsBlackListed = true; // Reset as request failed.
        }

        public async Task ToggleBlackListAsync(bool toggle)
        {
            try
            {
                var url = $"{_baseUrl}/api/" + (toggle ? "blacklistEnable" : "blacklistDisable");
                var response = await _httpClient.GetFromJsonAsync<RouterHosts>(url);

                if (response?.Success == true)
                {
                    if (toggle)
                    {
                        StatusMessageGreen = "Blacklist Enabled";
                    }
                    else
                    {
                        StatusMessageBlue = "Blacklist Disabled";
                    }

                    return;
                }

                StatusMessageRed = response?.Error;
            }
            catch (Exception ex)
            {
                StatusMessageRed = "Error fetching device data: " + ex.Message;
            }
        }

        public async Task SetStaticHostIP(string newDhcpValue, RouterHost host)
        {
            try
            {
                var url = $"{_baseUrl}/api/staticHostAdd?mac={host.Mac}&ip={newDhcpValue}";
                var response = await _httpClient.GetFromJsonAsync<RouterHosts>(url);

                if (response?.Success == true)
                {
                    StatusMessageBlue = "Static IP Address Updated: " + newDhcpValue;
                    return;
                }

                StatusMessageRed = response?.Error;
            }
            catch (Exception ex)
            {
                StatusMessageRed = "Error fetching device data: " + ex.Message;
            }
        }

        public async Task HostPacketCountersAsync(RouterHosts hosts)
        {
            try
            {
                var url = $"{_baseUrl}/api/hostPacketCounters";
                var response = await _httpClient.GetFromJsonAsync<DevicesResponse>(url);

                if (response?.Success == true)
                {
                    foreach(var item in response.Devices)
                    {
                        var host = hosts.HostList.Find(x => x.Mac == item.Mac);
                        if (host != null)
                        {
                            host.PacketCountSent = item.SentDataCount;
                            host.PacketCountReceived = item.ReceivedDataCount;
                        }
                    }

                    return;
                }

                StatusMessageRed = response?.Error;
            }
            catch (Exception ex)
            {
                StatusMessageRed = "Error fetching device data: " + ex.Message;
            }
        }
    }
}
