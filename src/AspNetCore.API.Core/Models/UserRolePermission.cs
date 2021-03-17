using AspNetCore.API.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Models
{
    public class UserRolePermission : Permission
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
