using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WhatsApp.Api.Otp.Common.Request;
using WhatsApp.Api.Otp.Common.Response;
using WhatsApp.Api.Otp.Contracts;
using WhatsApp.Api.Otp.Utilities;

namespace WhatsApp.Api.Otp.Services
{
    public class WAOtpService : IWAOtpService
    {
        private readonly IWAOtpHttpClient _wAOtpApiClient;
        private readonly ILogger<WAOtpService> _logger;

        public WAOtpService(IWAOtpHttpClient wAOtpApiClient,
            ILogger<WAOtpService> logger)
        {
            _wAOtpApiClient = wAOtpApiClient;
            _logger = logger;
        }

        public async Task<ApiResponse> SendOtpMessageAsync(OtpMessageModel message)
        {
            try
            {
                var response = await _wAOtpApiClient.SendOtpAsync(message.MapToWAMessage());

                if (response.IsSuccessStatusCode)
                {
                    var successResponse = await response.DeserializeResponse<WAMessageResponse>();
                    _logger.LogInformation($"Message sent successfully. Response: {JsonConvert.SerializeObject(successResponse)}");
                    return new ApiResponse(true);
                }
                else
                {
                    var errorResponse = await response.DeserializeResponse<WAErrorResponse>();
                    _logger.LogError($"An error occurred while sending the message. Error: {JsonConvert.SerializeObject(errorResponse)}");
                    return new ApiResponse(false)
                    {
                        Error = new ApiErrorResponse
                        {
                            Message = errorResponse.Error.Message,
                            ErrorCode = errorResponse.Error.Code.ToString(),
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending the Otp message.");
                throw;
            }
        }
    }
}
