using System.Threading.Tasks;
using WhatsApp.Api.Otp.Common.Request;
using WhatsApp.Api.Otp.Common.Response;

namespace WhatsApp.Api.Otp.Contracts
{
    /// <summary>
    /// Represents the interface for sending WhatsApp OTP messages.
    /// </summary>
    public interface IWAOtpService
    {
        /// <summary>
        /// Sends an WhatsApp OTP message asynchronously.
        /// </summary>
        /// <param name="message">The OTP message model.</param>
        /// <returns>The API response.</returns>
        Task<ApiResponse> SendOtpMessageAsync(OtpMessageModel message);
    }
}