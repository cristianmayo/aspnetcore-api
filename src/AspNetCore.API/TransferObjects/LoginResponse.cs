using System;

namespace AspNetCore.API.TransferObjects
{
    public class LoginResponse
    {
        public int AuthValidationResult { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string AccessToken { get; set; }
        public DateTime? AccessExpiration { get; set; }
    }
}
