using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Models.Domain
{
    public class JoinRequest
    {
        public Guid Id { get; set; }
        [MaxLength(256)]
        public string RequestDescription { get; set; }


        public Guid MemberId { get; set; }
        public Member Member { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
