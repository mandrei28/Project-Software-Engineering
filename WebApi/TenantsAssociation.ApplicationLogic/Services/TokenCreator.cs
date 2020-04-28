using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using Microsoft.Extensions.Options;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class TokenCreator : ITokenCreator
    {
        private readonly AppSettings _appSettings;
        public TokenCreator(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string CreateToken(Guid userId, string name, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secrettttttttttttttttttttttttttt");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
