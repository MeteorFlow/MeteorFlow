using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MeteorFlow.Core.Models;
using MeteorFlow.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Account = MeteorFlow.Core.Entities.Account;

namespace MeteorFlow.Infrastructure.Jwt
{
    public class JwtService(
        IUserClaimsPrincipalFactory<Account> claimsPrincipal,
        IOptions<JwtSettings> jwtSettings,
        UserManager<Account> accountManager)
        : IJwtService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        private async ValueTask<Token> _generateTokenAsync(Account entity)
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

        private async Task<IEnumerable<Claim>> _getClaimsAsync(Account account)
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