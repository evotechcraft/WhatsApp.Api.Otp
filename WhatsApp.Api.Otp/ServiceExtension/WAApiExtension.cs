using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Net.Http.Headers;
using WhatsApp.Api.Otp.Common.AppSettings;
using WhatsApp.Api.Otp.Contracts;
using WhatsApp.Api.Otp.Services;

namespace WhatsApp.Api.Otp.ServiceExtension
{
    /// <summary>
    /// Provides extension methods to configure WhatsApp.Api.Otp dependencies.
    /// </summary>
    public static class WAApiExtension
    {
        /// <summary>
        /// Adds WhatsApp.Api.Otp dependencies to the service collection.
        /// </summary>
        /// <param name="service">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="configSectionName">The name of the configuration section (optional).</param>
        public static void AddWAApiDependency(this IServiceCollection service, IConfiguration configuration, string? configSectionName = "WhatsAppConfigurations")
        {
            service.Configure<WhatsAppApiConfigurations>(options => configuration.GetSection(configSectionName).Bind(options));

            var whatsAppConfigs = service.BuildServiceProvider().GetRequiredService<IOptions<WhatsAppApiConfigurations>>().Value;

            var refitSettings = new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new DefaultContractResolver
                            {
                                NamingStrategy = new SnakeCaseNamingStrategy()
                            },
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            NullValueHandling = NullValueHandling.Ignore,
                            DefaultValueHandling = DefaultValueHandling.Include
                        }
                    )
            };

            service.AddRefitClient<IWAOtpHttpClient>(refitSettings)
                     .ConfigureHttpClient(c =>
                     {
                         c.BaseAddress = new Uri($"{whatsAppConfigs.ApiUrl}/{whatsAppConfigs.Version}/{whatsAppConfigs.PhoneNumberId}");
                         c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                         c.DefaultRequestHeaders.Add("Authorization", $"Bearer {whatsAppConfigs.AccessToken}");
                     });

            service.AddScoped<IWAOtpService, WAOtpService>();

        }
    }
}
