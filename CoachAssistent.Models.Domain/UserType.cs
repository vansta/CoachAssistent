using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoachAssistent.Models.Domain
{
    public class UserType
    {
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
