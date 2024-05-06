using System.Security.Claims;
using System.Text;
using MeteorFlow.Auth.Models;
using MeteorFlow.Fx.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MeteorFlow.Auth.Jwt;

public class GenerateJwtTokenCommand: ICommand<string>
{
    public string Username { get; set; }
}

internal class GenerateJwtTokenCommandHandler(SecurityTokenHandler tokenHandler, IConfiguration configuration)
    : ICommandHandler<GenerateJwtTokenCommand, string>
{
    public Task<string> HandleAsync(GenerateJwtTokenCommand command, CancellationToken cancellationToken = default)
    {
        var jwtSettings = configuration
            .GetSection(nameof(JwtSettings))
            .Get<JwtSettings>();
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey); // Replace with your secret key
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, command.Username) }),
            Issuer= "statsApp",
            Audience= "https://localhost:7187/",
            Expires = DateTime.UtcNow.AddHours(1), // Set the token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}