﻿using AutoMapper;
using CoachAssistent.Models.Domain;
using CoachAssistent.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers.MapProfiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubViewModel>();

            CreateMap<CreateClubViewModel, Club>();
        }
    }
}
