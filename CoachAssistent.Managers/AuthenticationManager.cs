using AutoMapper;
using CoachAssistent.Data;
using CoachAssistent.Data.SeedingLibrary;
using CoachAssistent.Models.Domain;
using CoachAssistent.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers
{
    public interface IAuthenticationManager
    {
        Task<string> Login(LoginViewModel loginViewModel);
        Task<string> Register(RegisterViewModel registerViewModel);
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        readonly CoachAssistentDbContext dbContext;
        readonly IMapper mapper;
        readonly IConfiguration _configuration;
        public AuthenticationManager(CoachAssistentDbContext context, IMapper _mapper, IConfiguration configuration)
        {
            dbContext = context;
            mapper = _mapper;
            _configuration = configuration;
        }
        public async Task<string> Register(RegisterViewModel registerViewModel)
        {
            if (await dbContext.Credentials.AnyAsync(c => c.UserName.Equals(registerViewModel.Email)))
            {
                throw new Exception($"username {registerViewModel.Email} already exists");
            }
            Member member = mapper.Map<Member>(registerViewModel);
            member.UserTypeId = UserTypeLibrary.Free.Id;
            member = dbContext.Members.Add(member).Entity;

            Credential credential = mapper.Map<Credential>(registerViewModel);
            credential.EncryptPassword(registerViewModel.Password);

            credential.MemberId = member.Id;

            var credentialTask = dbContext.Credentials.AddAsync(credential);

            //foreach (Guid groupId in registerViewModel.GroupIds)
            //{
            //    dbContext.JoinRequests.Add(new JoinRequest
            //    {
            //        MemberId = member.Id,
            //        GroupId = groupId
            //    });
            //}

            await credentialTask;
            await dbContext.SaveChangesAsync();

            return JwtCreator.CreateJwt(_configuration.GetSection("JWT"), credential);
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {            
            Credential credential = await dbContext.Credentials
                .Include(c => c.User)
                .SingleOrDefaultAsync(c => c.UserName.Equals(loginViewModel.UserName));

            if (credential != null)
            {
                if (credential.VerifyPassword(loginViewModel.Password))
                {
                    return JwtCreator.CreateJwt(_configuration.GetSection("JWT"), credential);
                }
                else
                {
                    throw new Exception($"Incorrect password for {loginViewModel.UserName}");
                }
            }
            else
            {
                throw new Exception($"No user found for {loginViewModel.UserName}");
            }
        }
    }
}
