using MeteorFlow.Core.Models;

namespace MeteorFlow.Infrastructure.Extensions;

public interface IJwtService
{
    ValueTask<Token> GenerateTokenFromUserName(string userName);
}