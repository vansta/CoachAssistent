using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachAssistent.Models.Domain
{
    public class Member
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(256), EmailAddress]
        public string Email { get; set; }

        public Guid UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
