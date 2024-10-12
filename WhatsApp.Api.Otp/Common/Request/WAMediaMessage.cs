using Newtonsoft.Json;

namespace WhatsApp.Api.Otp.Common.Request
{
    public class MediaMessageBase
    {
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class WAMediaMessage : MediaMessageBase
    {
        [JsonProperty("caption")]
        public string? Caption { get; set; }
    }

    public class MediaDocument : WAMediaMessage
    {

        [JsonProperty("filename")]
        public string Filename { get; set; }

    }
}
