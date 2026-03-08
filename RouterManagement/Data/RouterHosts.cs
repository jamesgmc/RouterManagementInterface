using System.Text.Json.Serialization;

namespace RouterManagement.Data.Models
{
    public class RouterResponse
    {
        public RouterResponse() { }
        public RouterResponse(string errorMessage)
        {
            Success = false;
            Error = errorMessage;
        }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }
    }

    public class AddToBlackListResponse : RouterResponse
    {
        [JsonPropertyName("blackListHostId")]
        public string BlackListHostId { get; set; }

        [JsonPropertyName("blackListRuleId")]
        public string BlackListRuleId { get; set; }
    }

    public class RouterHosts : RouterResponse
    {
        public RouterHosts(){}

        public RouterHosts(string errorMessage) : base(errorMessage)
        {
        }

        [JsonPropertyName("blackListEnabled")]
        public bool BlackListEnabled { get; set; }

        [JsonPropertyName("hosts")]
        public List<RouterHost> HostList { get; set; }
    }

    public class RouterHost
    {
        [JsonPropertyName("mac")]
        public string Mac { get; set; }

        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        [JsonPropertyName("connectionType")]
        public string ConnectionType { get; set; }

        [JsonPropertyName("ip")]
        public string IP { get; set; }

        [JsonPropertyName("isOnline")]
        public bool IsOnline { get; set; }

        [JsonPropertyName("isBlackListed")]
        public bool IsBlackListed { get; set; }

        [JsonPropertyName("blackListHostId")]
        public string BlackListHostId { get; set; }

        [JsonPropertyName("blackListRuleId")]
        public string BlackListRuleId { get; set; }

        [JsonPropertyName("lease")]
        public string Lease { get; set; }

        [JsonPropertyName("leaseTime")]
        public string LeaseTime { get; set; }

        [JsonPropertyName("blackListName")]
        public string BlackListName { get; set; }

        [JsonPropertyName("packetCountReceived")]
        public int PacketCountReceived { get; set; }

        [JsonPropertyName("packetCountSent")]
        public int PacketCountSent {  get; set; }
    }
}
