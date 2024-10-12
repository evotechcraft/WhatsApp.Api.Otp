using Newtonsoft.Json;
using System.Collections.Generic;

namespace WhatsApp.Api.Otp.Common.Request
{
    public class WATemplateMessage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("language")]
        public MessageLanguage Language { get; set; }

        [JsonProperty("components")]
        public List<MessageComponent> Components { get; set; }
    }

    public class MessageComponent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("sub_type")]
        public string SubType { get; set; }

        [JsonProperty("parameters")]
        public List<MessageParameter> Parameters { get; set; }
    }

    public class MessageParameter
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("image")]
        public TemplateMedia? Image { get; set; }

        [JsonProperty("video")]
        public TemplateMedia? Video { get; set; }
        [JsonProperty("document")]
        public TemplateMedia? Document { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("currency")]
        public TemplateCurrency? Currency { get; set; }

        [JsonProperty("date_time")]
        public TemplateDateTime? DateTime { get; set; }
    }

    public class TemplateCurrency
    {
        [JsonProperty("fallback_value")]
        public string FallbackValue { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("amount_1000")]
        public long Amount1000 { get; set; }
    }

    public class TemplateDateTime
    {
        [JsonProperty("fallback_value")]
        public string FallbackValue { get; set; }

        [JsonProperty("day_of_week")]
        public int DayOfWeek { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("day_of_month")]
        public int DayOfMonth { get; set; }

        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("minute")]
        public int Minute { get; set; }

        [JsonProperty("calendar")]
        public string Calendar { get; set; }
    }

    public class TemplateMedia
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class MessageLanguage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("policy")]
        public string Policy { get; set; }
    }
}
