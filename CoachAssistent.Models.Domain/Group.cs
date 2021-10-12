using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoachAssistent.Models.Domain
{
    public class Group
    {
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }

        public Guid ClubId { get; set; }
        public virtual Club Club { get; set; }
        public virtual ICollection<Member> Users { get; set; }
    }
}
