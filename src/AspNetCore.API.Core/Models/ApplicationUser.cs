using AspNetCore.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCore.API.Core.Models
{
    public class ApplicationUser : User
    {
        [Key]
        public override Guid UserId { get; set; }
    }
}
