using System.Collections.Generic;
using WhatsApp.Api.Otp.Common.Constants;
using WhatsApp.Api.Otp.Common.Request;

namespace WhatsApp.Api.Otp.Utilities
{
    public static class CommonMapper
    {
        public static WAMessage MapToWAMessage(this OtpMessageModel message)
        {
            return new WAMessage(CMessageTypes.Template)
            {
                To = message.RecipientNumber,
                Template = new WATemplateMessage
                {
                    Name = message.TemplateName,
                    Language = new MessageLanguage { Code = message.Language.ToString() },
                    Components = new List<MessageComponent>
                        {
                            new MessageComponent
                            {
                                Type = "body",
                                Parameters = new List<MessageParameter>
                                {
                                    new MessageParameter
                                    {
                                        Type = "text",
                                        Text = message.Otp
                                    }
                                }
                            },
                            new MessageComponent
                            {
                                Type = "button",
                                SubType = "url",
                                Index = "0",
                                Parameters = new List<MessageParameter>
                                {
                                    new MessageParameter
                                    {
                                        Type = "text",
                                        Text = message.Otp
                                    }
                                }
                            }
                        }
                },
            };
        }
    }
}
