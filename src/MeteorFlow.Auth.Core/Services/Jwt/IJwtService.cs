
using MeteorFlow.Auth.Core.Entities;

namespace MeteorFlow.Auth.Core.Services.Jwt;

public interface IJwtService
{
    ValueTask<Token> GenerateTokenFromUserName(string userName);
}