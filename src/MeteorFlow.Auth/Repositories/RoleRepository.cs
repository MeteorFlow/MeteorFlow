using MeteorFlow.Auth.Entities;
using MeteorFlow.Fx.DateTimes;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Auth.Repositories;

public class RoleRepository(AuthDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<Role, Guid>(dbContext, dateTimeProvider), IRoleRepository
{
    public IQueryable<Role> Get(RoleQueryOptions queryOptions)
    {
        var query = GetQueryableSet();

        if (queryOptions.IncludeClaims)
        {
            query = query.Include(x => x.Claims);
        }

        if (queryOptions.IncludeUserRoles)
        {
            query = query.Include(x => x.UserRoles);
        }

        if (queryOptions.IncludeUsers)
        {
            query = query.Include("UserRoles.User");
        }

        if (queryOptions.AsNoTracking)
        {
            query = query = query.AsNoTracking();
        }

        return query;
    }
}