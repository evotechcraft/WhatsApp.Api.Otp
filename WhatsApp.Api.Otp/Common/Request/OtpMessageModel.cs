using WhatsApp.Api.Otp.Common.Enums;

namespace WhatsApp.Api.Otp.Common.Request
{
    public class OtpMessageModel
    {
        public string TemplateName { get; set; }
        public string RecipientNumber { get; set; }
        public string Otp { get; set; }
        public ETemplateLanguage Language { get; set; }
    }
}
