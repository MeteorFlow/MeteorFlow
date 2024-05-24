using System.Security.Claims;
using System.Text;
using MeteorFlow.Auth.Models;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using User = MeteorFlow.Auth.Entities.User;

namespace MeteorFlow.Auth.Jwt;

public class GenerateJwtTokenCommand: ICommand<string>
{
    public User User { get; set; }
}

internal class GenerateJwtTokenCommandHandler(SecurityTokenHandler tokenHandler, ICurrentUser user, IUserClaimsPrincipalFactory<User> claimsPrincipalFactory, IConfiguration configuration)
    : ICommandHandler<GenerateJwtTokenCommand, string>
{
    public async Task<string> HandleAsync(GenerateJwtTokenCommand command, CancellationToken cancellationToken = default)
    {
        var jwtSettings = configuration
            .GetSection(nameof(JwtSettings))
            .Get<JwtSettings>();
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey); // Replace with your secret key
        
        if (jwtSettings == null) throw new Exception("JwtSettings is null");
        
        if (command.User == null) throw new Exception("User is null");
        
        var claimsPrincipal = await claimsPrincipalFactory.CreateAsync(command.User);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = (ClaimsIdentity)claimsPrincipal.Identity,
            Claims = claimsPrincipal.Claims.ToDictionary(c => c.Type, c => (object)c.Value),
            Issuer= jwtSettings.Issuer,
            Audience= jwtSettings.Audience,
            Expires = DateTime.UtcNow.AddHours(1), // Set the token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}