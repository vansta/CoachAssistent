using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoachAssistent.Models.Domain
{
    public class Club
    {
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
