using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WhatsApp.Api.Otp.Utilities
{
    public static class HttpResponseDeserializer
    {
        public static async Task<T> DeserializeResponse<T>(this HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
