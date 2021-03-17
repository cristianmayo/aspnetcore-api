using System;

namespace AspNetCore.API.TransferObjects
{
    public class LoginRequest
    {
        public Guid ClientId { get; set; }
        public Guid UserId { get; set; }
        public string Password { get; set; }
    }
}
