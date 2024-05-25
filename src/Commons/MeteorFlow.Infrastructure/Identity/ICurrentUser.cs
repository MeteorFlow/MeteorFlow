namespace MeteorFlow.Infrastructure.Identity;

public interface ICurrentUser
{
    bool IsAuthenticated { get; }

    Guid UserId { get; }
}