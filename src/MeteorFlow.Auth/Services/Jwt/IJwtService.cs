using MeteorFlow.Auth.Entities;

namespace MeteorFlow.Auth.Services.Jwt;

public interface IJwtService
{
    ValueTask<Token> GenerateTokenFromUserName(string userName);
}