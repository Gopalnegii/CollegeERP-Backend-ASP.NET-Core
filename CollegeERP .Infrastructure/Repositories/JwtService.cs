using CollegeERP.Domain.Data.Entities;
using CollegeERP_.Application.Common.Options;
using CollegeERP_.Application.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;

namespace CollegeERP_.Application.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _options;
        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role,user.Role.RoleName)
            };
            var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_options.Key));

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(_options.ExpiresInMinutes);

            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
