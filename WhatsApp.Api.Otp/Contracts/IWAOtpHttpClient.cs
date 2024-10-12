using Refit;
using System.Net.Http;
using System.Threading.Tasks;
using WhatsApp.Api.Otp.Common.Request;

namespace WhatsApp.Api.Otp.Contracts
{
    /// <summary>
    /// Represents the contract for the WhatsApp API OTP HTTP client.
    /// </summary>
    public interface IWAOtpHttpClient
    {
        /// <summary>
        /// Sends an WhatsApp OTP message asynchronously.
        /// </summary>
        /// <param name="body">The message body.</param>
        /// <returns>The HTTP response message.</returns>
        [Post("/messages")]
        Task<HttpResponseMessage> SendOtpAsync([Body] WAMessage body);
    }
}
