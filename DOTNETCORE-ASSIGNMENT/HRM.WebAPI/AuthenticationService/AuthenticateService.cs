using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM.WebAPI.JWTConfig;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace HRM.WebAPI.AuthenticationService
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly Config _config;

        public AuthenticateService(IOptions<Config> config)
        {
            _config = config.Value;
        }

        /// <summary>
        /// Static list for User Credentials
        /// </summary>
        private List<UserLogin> users = new List<UserLogin>()
        {
            new UserLogin
            {
                Email = "admin@admin.com",
                Password = "admin@123"
            }
        };


        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public UserLogin Authenticate(string Email, string Password)
        {
            var user = users.SingleOrDefault(u => u.Email.ToLower() == Email && u.Password == Password);
            if(user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Password = null;
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
