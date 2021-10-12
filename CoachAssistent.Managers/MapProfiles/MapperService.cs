using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers.MapProfiles
{
    public static class MapperService
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClubProfile());
                mc.AddProfile(new CredentialProfile());
                mc.AddProfile(new GroupProfile());
                mc.AddProfile(new UserProfile());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
