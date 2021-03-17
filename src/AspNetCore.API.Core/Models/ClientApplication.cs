using AspNetCore.API.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Models
{
    public class ClientApplication : ClientApp
    {
        [Key]
        public override Guid ClientId { get; set; }
    }
}
