using AutoMapper;
using CoachAssistent.Data;
using CoachAssistent.Managers;
using CoachAssistent.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachAssistent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupManager groupManager;
        public GroupController(CoachAssistentDbContext context, IMapper mapper)
        {
            groupManager = new GroupManager(context, mapper);
        }
        [HttpGet]
        public IEnumerable<GroupViewModel> Get(Guid? id)
        {
            return groupManager.Get(id);
        }

        [HttpPost]
        public Task Create(CreateGroupViewModel createViewModel)
        {
            return groupManager.Create(createViewModel);
        }
    }
}
