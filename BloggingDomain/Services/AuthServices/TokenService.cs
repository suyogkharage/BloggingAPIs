using BloggingDomain.Interfaces;
using BloggingDomain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BloggingDomain.Services.AuthServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");

            _configuration = new ConfigurationBuilder()
                                .AddJsonFile(appSettingsPath)
                                .Build();
        }
        public string CreateToken(string username)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes
                (_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
