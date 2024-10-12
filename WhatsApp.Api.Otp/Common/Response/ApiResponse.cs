namespace WhatsApp.Api.Otp.Common.Response
{
    public class ApiResponse
    {
        public ApiResponse(bool isSuccess = true)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
        public ApiSuccessResponse? Success { get; set; }
        public ApiErrorResponse? Error { get; set; }
    }
}
