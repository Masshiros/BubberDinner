using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BubberDinner.Application.Common.Interfaces.Auth;
using BubberDinner.Application.Common.Interfaces.Services;
using BubberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BubberDinner.Infrastructure.Authentication
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;
        public JwtGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings>  jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }
        public string GenerateJwtToken(User user)
        {
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName)
            };
            var securityToken = new JwtSecurityToken(issuer: _jwtSettings.Issuer , audience:_jwtSettings.Audience, expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes), claims: claims,signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
