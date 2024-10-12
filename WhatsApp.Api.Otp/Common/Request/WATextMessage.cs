using Newtonsoft.Json;

namespace WhatsApp.Api.Otp.Common.Request
{
    public class WhatsAppText
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class Context
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
    }
}
