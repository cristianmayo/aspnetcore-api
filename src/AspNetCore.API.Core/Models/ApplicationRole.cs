using AspNetCore.API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Models
{
    public class ApplicationRole : Role
    {
        [Key]
        public int Id { get; set; }
    }
}
