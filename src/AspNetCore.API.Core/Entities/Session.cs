using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Entities
{
    public abstract class Session
    {
        public bool IsActive { get; set; }

        [DataType(DataType.Text)]
        public string AccessToken { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AccessExpiration { get; set; }
    }
}
