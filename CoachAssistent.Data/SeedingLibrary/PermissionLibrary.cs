using CoachAssistent.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Data.SeedingLibrary
{
    public class PermissionLibrary
    {
        public static Permission CreateUser
        {
            get
            {
                return new Permission
                {
                    Id = Guid.Parse("ec7ebcff-5e08-45e1-bf40-1b94d7f1f5e8"),
                    Action = "Create",
                    Subject = "User"
                };
            }
        }

        public static Permission CreateGroup
        {
            get
            {
                return new Permission
                {
                    Id = Guid.Parse("3fb06b3c-d0e9-4fe0-803a-8ad4f044d268"),
                    Action = "Create",
                    Subject = "Group"
                };
            }
        }
    }
}
