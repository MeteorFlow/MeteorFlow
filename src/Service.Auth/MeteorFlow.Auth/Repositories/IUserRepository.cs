using MeteorFlow.Auth.Entities;

namespace MeteorFlow.Auth.Repositories;

public class UserQueryOptions
{
    public bool IncludeClaims { get; set; }
    public bool IncludeUserRoles { get; set; }
    public bool IncludeRoles { get; set; }
    public bool IncludeTokens { get; set; }
    public bool AsNoTracking { get; set; }
}

public interface IUserRepository : IAuthRepository<User>
{
    IQueryable<User> Get(UserQueryOptions queryOptions);
}