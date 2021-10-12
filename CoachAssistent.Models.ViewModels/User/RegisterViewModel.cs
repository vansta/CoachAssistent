using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoachAssistent.Models.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress, Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Guid> GroupIds { get; set; }
    }
}
