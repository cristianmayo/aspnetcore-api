using System;

namespace AspNetCore.API.TransferObjects
{
    public class AuthCheckResponse
    {
        public int AuthCheckResult { get; set; }
        public bool? AuthorizedClient { get; set; }
        public bool? ValidUsername { get; set; }
        public Guid? UserId { get; set; }
    }
}
