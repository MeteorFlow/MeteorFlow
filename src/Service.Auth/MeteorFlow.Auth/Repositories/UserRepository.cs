using MeteorFlow.Auth.Entities;
using MeteorFlow.Fx.DateTimes;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Auth.Repositories;

public class UserRepository : Repository<User, Guid>, IUserRepository
{
    public UserRepository(AuthDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }

    public IQueryable<User> Get(UserQueryOptions queryOptions)
    {
        var query = GetQueryableSet();
        if (queryOptions.IncludeTokens)
        {
            query = query.Include(x => x.Tokens);
        }

        if (queryOptions.IncludeClaims)
        {
            query = query.Include(x => x.Claims);
        }

        if (queryOptions.IncludeUserRoles)
        {
            query = query.Include(x => x.UserRoles);
        }

        if (queryOptions.IncludeRoles)
        {
            query = query.Include("UserRoles.Role");
        }

        if (queryOptions.AsNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }
}