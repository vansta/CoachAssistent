using System;
using System.Collections.Generic;
using System.Text;

namespace CoachAssistent.Models.Domain
{
    public class RolePermission
    {
        public Guid Id { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
