# WhatsApp API OTP

A free and open source .NET NuGet package to facilitate sending OTP messages through WhatsApp Business APIs. This package provides a simple and efficient way to deliver OTP messages, ensuring they reach your users swiftly and securely.

## Features

- Easy integration with WhatsApp Business APIs.
- Send OTP messages with minimal setup.
- Secure and reliable delivery.
- Lightweight and efficient.

## Sample .NET Api project using this nuget package

WhatsApp Api Otp Demo Git Repository - https://github.com/evotechcraft/WhatsApp.Api.Demo

## Installation

To install the package, use the NuGet Package Manager Console:
Install-Package WhatsApp.Api.Otp


Or use the .NET CLI:
dotnet add package WhatsApp.Api.Otp


## Usage

Here's a basic example of how to use the WhatsApp.Api.Otp in your project:

```csharp
using Microsoft.AspNetCore.Mvc;
using WhatsApp.Api.Otp.Common.Request;
using WhatsApp.Api.Otp.Contracts;

namespace whatsapp_otp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsappMessageController : ControllerBase
    {
        private IWAOtpService _wAOtp;

        public WhatsappMessageController(IWAOtpService wAOtp)
        {
            _wAOtp = wAOtp;
        }

        [HttpPost("SendOtpMessage")]
        public async Task<IActionResult> SendOtpMessage(OtpMessageModel message)
        {
            var response = await _wAOtp.SendOtpMessageAsync(message);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

```

### Appsettings:

``` json
"WhatsAppConfigurations": {
  "ApiUrl": "https://graph.facebook.com",
  "PhoneNumberId": "{{PhoneNumberId}}",
  "AccessToken": "{{AccessToken}}",
  "Version": "v20.0"
}
```
Replace placeholders like `"{{PhoneNumberId}}"` and `"{{AccessToken}}"` with the appropriate details as necessary.

### Adds WhatsApp.Api.Otp dependencies to the service collection.

``` csharp
/// <summary>
/// Adds WhatsApp.Api.Otp dependencies to the service collection.
/// </summary>
/// <param name="service">The service collection.</param>
/// <param name="configuration">The configuration.</param>
/// <param name="configSectionName">The name of the configuration section (optional).</param>

builder.Services.AddWAApiDependency(builder.Configuration, "WhatsAppConfigurations");

```

### Request class
``` csharp
public class OtpMessageModel
{
    public string TemplateName { get; set; }
    public string RecipientNumber { get; set; }
    public string Otp { get; set; }
    public ETemplateLanguage Language { get; set; }
}
```

## License
This project is licensed under the MIT License. See the LICENSE file for more details.

## Support
contact mail: sales@evotechcraft.com.

## Changelog
Make sure to check the CHANGELOG for any updates or changes.

***

I made minor adjustments to clarify instructions, improved readability, and formatted code examples for consistency. Let me know if you need further refinement!
