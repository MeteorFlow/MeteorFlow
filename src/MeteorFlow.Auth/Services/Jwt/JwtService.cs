using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Models;
// using MeteorFlow.Infrastructure.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MeteorFlow.Auth.Services.Jwt
{
    public class JwtService(
        IUserClaimsPrincipalFactory<User> claimsPrincipal,
        IOptions<JwtSettings> jwtSettings,
        UserManager<User> accountManager)
        : IJwtService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        private async ValueTask<Token> _generateTokenAsync(User entity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = await _getClaimsAsync(entity);
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(0),
                Expires = DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(claims)
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new Token
            {
                AccessToken = tokenHandler.WriteToken(securityToken),
                ExpiresIn = (int)securityToken.ValidTo.Subtract(DateTime.Now).TotalSeconds
            };
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync(User account)
        {
            var result = await claimsPrincipal.CreateAsync(account);
            return result.Claims;
        }

        public async ValueTask<Token> GenerateTokenFromUserName(string userName)
        {
            return await _generateTokenAsync(await accountManager.FindByNameAsync(userName));
        }
    }
}