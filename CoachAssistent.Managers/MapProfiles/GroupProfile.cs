using AutoMapper;
using CoachAssistent.Models.Domain;
using CoachAssistent.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers.MapProfiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupViewModel>()
                .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club == null ? null : src.Club.Name));

            CreateMap<CreateGroupViewModel, Group>();
        }
    }
}
