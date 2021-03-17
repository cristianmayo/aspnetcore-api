using AspNetCore.API.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Models
{
    public class ClientUserSession : Session
    {
        [Key]
        public int Id { get; set; }

        public ClientApplication Client { get; set; }

        public ApplicationUser User { get; set; }
    }
}
