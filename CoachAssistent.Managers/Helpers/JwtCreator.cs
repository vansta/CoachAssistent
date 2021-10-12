using CoachAssistent.Models.Domain;
using CoachAssistent.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoachAssistent.Managers
{
    public static class JwtCreator
    {
        internal static string CreateJwt(IConfigurationSection configuration, Credential credential)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, credential.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Secret")));

            var token = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("ValidIssuer"),
                audience: configuration.GetValue<string>("ValidAudience"),
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static TokenValidationParameters CreateValidationParameters(IConfigurationSection configuration)
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration.GetValue<string>("ValidAudience"),
                ValidIssuer = configuration.GetValue<string>("ValidIssuer"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Secret")))
            };
        }
    }
}
