
using MeteorFlow.Auth.Core.Entities;
using MeteorFlow.Core.Entities;

namespace MeteorFlow.Auth.Core.Repositories;

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