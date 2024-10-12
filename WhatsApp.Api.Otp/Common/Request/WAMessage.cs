using Newtonsoft.Json;

namespace WhatsApp.Api.Otp.Common.Request
{
    public class WAMessage
    {
        public WAMessage(string messageType)
        {
            Type = messageType;
        }
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; } = "whatsapp";


        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("preview_url")]
        public bool? PreviewUrl { get; set; }

        [JsonProperty("text")]
        public WhatsAppText Text { get; set; }

        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("image")]
        public WAMediaMessage Image { get; set; }

        [JsonProperty("audio")]
        public MediaMessageBase Audio { get; set; }

        [JsonProperty("document")]
        public MediaDocument Document { get; set; }

        [JsonProperty("sticker")]
        public WAMediaMessage Sticker { get; set; }

        [JsonProperty("template")]
        public WATemplateMessage Template { get; set; }

        [JsonProperty("video")]
        public WAMediaMessage Video { get; set; }

    }
}