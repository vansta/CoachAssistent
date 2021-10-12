using CoachAssistent.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Data.SeedingLibrary
{
    public static class RoleLibrary
    {
        public static Role Admin
        {
            get
            {
                return new Role
                {
                    Id = Guid.Parse("933d4df2-8bb6-4e71-af5a-dc2e7d32002d"),
                    Name = "Administrator"
                };
            }
        }

        public static Role Coach
        {
            get
            {
                return new Role
                {
                    Id = Guid.Parse("1d5ecb8d-d752-410a-b733-48b1760b331f"),
                    Name = "Coach"
                };
            }
        }

        public static Role Player
        {
            get
            {
                return new Role
                {
                    Id = Guid.Parse("fe5e7385-5056-4220-9978-39ad5e6e2aec"),
                    Name = "Player"
                };
            }
        }
    }
}
