
using MeteorFlow.Core.Fx.Identities;

namespace MeteorFlow.Cloud.Auth.Services.Jwt;

public interface IJwtService
{
    ValueTask<Token> GenerateTokenFromUserName(string userName);
}