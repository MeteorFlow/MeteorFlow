namespace MeteorFlow.Auth.Core.Persistence;

public interface IIdentityContext
{
    Task<int> SaveChangesAsync();
}