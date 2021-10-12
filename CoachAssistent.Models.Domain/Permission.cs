using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoachAssistent.Models.Domain
{
    public class Permission
    {
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Action { get; set; }
        [Required, MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
