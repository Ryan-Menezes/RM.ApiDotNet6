using Microsoft.IdentityModel.Tokens;
using RM.ApiDotNet6.Domain.Authentication;
using RM.ApiDotNet6.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RM.ApiDotNer6.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString()),
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("c6PK94YIIjHAxjsN48tmlSKNxHvqqJY1"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                expires: expires,
                claims: claims
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);

            return new
            {
                access_token = token,
                expirations = expires,
            };
        }
    }
}
