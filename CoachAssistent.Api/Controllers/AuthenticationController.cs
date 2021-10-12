using AutoMapper;
using CoachAssistent.Data;
using CoachAssistent.Managers;
using CoachAssistent.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachAssistent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        readonly IAuthenticationManager authenticationManager;
        public AuthenticationController(CoachAssistentDbContext context, IMapper mapper, IConfiguration configuration)
        {
            authenticationManager = new AuthenticationManager(context, mapper, configuration);
        }

        [HttpPost]
        public Task<string> Login(LoginViewModel login)
        {
            return authenticationManager.Login(login);
        }

        [HttpPost("Register")]
        public Task<string> Register(RegisterViewModel registerViewModel)
        {
            return authenticationManager.Register(registerViewModel);
        }
    }
}
