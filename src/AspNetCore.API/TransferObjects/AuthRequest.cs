using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.API.TransferObjects
{
    public class AuthRequest
    {
        public Guid ClientId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
