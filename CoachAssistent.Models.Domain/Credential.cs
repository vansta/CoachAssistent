using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Models.Domain
{
    public class Credential
    {
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(512)]
        public string PasswordHash { get; set; }

        public Guid MemberId { get; set; }
        public virtual Member User { get; set; }
    }
}
