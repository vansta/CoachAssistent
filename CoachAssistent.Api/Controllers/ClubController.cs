using AutoMapper;
using CoachAssistent.Data;
using CoachAssistent.Managers;
using CoachAssistent.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachAssistent.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        readonly IClubManager clubManager;
        public ClubController(CoachAssistentDbContext context, IMapper mapper, IConfiguration configuration)
        {
            clubManager = new ClubManager(context, mapper, configuration);
        }

        [HttpGet]
        public IEnumerable<ClubViewModel> Get(string name)
        {
            return clubManager.Get(name);
        }

        [HttpPost]
        public Task Create(CreateClubViewModel createViewModel)
        {
            return clubManager.Create(createViewModel);
        }
    }
}
