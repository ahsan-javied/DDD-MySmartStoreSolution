using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Application.Helper
{
    public interface IJWTManager
    {
        string GenerateJwtToken(AuthenticatedUserDTO user);
    }

    public class JWTManager : IJWTManager
    {
        private readonly IConfiguration config;
        public JWTManager(IConfiguration iconfiguration)
        {
            config = iconfiguration;
        }

        public string GenerateJwtToken(AuthenticatedUserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.HasValue ? user.Id.Value.ToString() : null),
                    new Claim(ClaimTypes.NameIdentifier, user.FirstName.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.GivenName, user.LastName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
