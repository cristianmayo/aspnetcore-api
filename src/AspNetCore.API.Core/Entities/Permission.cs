using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.API.Core.Entities
{
    public abstract class Permission
    {
        public bool IsSystemAdministrator{ get; set; }
        public bool IsAdministratorOnly { get; set; }
        public bool IsUserOnly { get; set; }

        public bool AllowDisplay { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowChange { get; set; }
        public bool AllowDelete { get; set; }

    }
}
