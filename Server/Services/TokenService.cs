using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MFA.Server.Domain;
using MFA.Server.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MFA.Server.Services
{
    public class TokenService:ITokenService
    {
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly IEncrypter _encrypter;

        public TokenService(
            IOptions<JwtSettings> jwtSettings,
            IEncrypter encrypter)
        {
            _jwtSettings = jwtSettings;
            _encrypter = encrypter;
        }

        public string GenerateJwtToken(User user)
        {
            var now = DateTime.UtcNow;
            var issuer = _jwtSettings.Value.Issuer;
            var audience = _jwtSettings.Value.Audience;
            var expiryDate = now.AddMinutes(_jwtSettings.Value.ExpiryTime);
            var credencials = new SigningCredentials(new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Value.Key)), SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, audience),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: claims,
                notBefore: now,
                expires: expiryDate,
                signingCredentials: credencials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return _encrypter.GetSecureSalt(32);
        }
    }
}