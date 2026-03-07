using System.Text.Json.Serialization;

namespace RouterManagement.Data
{
    public class DevicesResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("devices")]
        public List<DeviceInfo> Devices { get; set; }
    }

    public class DeviceInfo
    {
        [JsonPropertyName("mac")]
        public string Mac { get; set; }

        [JsonPropertyName("sentDataCount")]
        public int SentDataCount { get; set; }

        [JsonPropertyName("receivedDataCount")]
        public int ReceivedDataCount { get; set; }
    }
}
