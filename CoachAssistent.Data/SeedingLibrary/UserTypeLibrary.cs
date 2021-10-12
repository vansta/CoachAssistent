using CoachAssistent.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Data.SeedingLibrary
{
    public class UserTypeLibrary
    {
        public static UserType Free
        {
            get
            {
                return new UserType
                {
                    Id = Guid.Parse("e936607b-fe4f-4f55-9bab-c353cde40767"),
                    Name = "Free user"
                };
            }
        }
    }
}
