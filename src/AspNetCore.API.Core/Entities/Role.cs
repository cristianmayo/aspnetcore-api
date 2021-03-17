using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Entities
{
    public abstract class Role
    {
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
