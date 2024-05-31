using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.DateTimes;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Repositories;

public class DefinitionRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<AppDefinitions, Guid>(dbContext, dateTimeProvider), IDefinitionRepository
{
    public IQueryable<AppDefinitions> Get(DefinitionQueryOptions queryOptions)
    {
        var query = GetQueryableSet();
        if (queryOptions.AsNoTracking)
        {
            query = query.AsNoTracking();
        }

        if (queryOptions.IncludeBase)
        {
            query = query.Include(x => x.BaseDefinition);
        }

        if (queryOptions.IncludeSub)
        {
            query = query.Include(x => x.SubDefinitions);
        }

        if (queryOptions.IncludeVersion)
        {
            query = query.Include(x =>
                x.AppVersionControls
                    .OrderByDescending(v => v.MajorVersion)
                    .ThenByDescending(v => v.MinorVersion)
                    .ThenByDescending(v => v.PatchVersion)
                );
        }

        return query;
    }
}