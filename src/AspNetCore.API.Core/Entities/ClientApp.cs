using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Entities
{
    public abstract class ClientApp
    {
        public virtual Guid ClientId { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        public bool IsEnabled { get; set; }

        public string ApplicationType { get; set; }

    }
}
