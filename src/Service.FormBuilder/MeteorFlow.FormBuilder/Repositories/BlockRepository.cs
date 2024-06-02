using MeteorFlow.FormBuilder.Entities;
using MeteorFlow.Fx.DateTimes;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.FormBuilder.Repositories;

public class BlockRepository(FormDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<FormBlocks, Guid>(dbContext, dateTimeProvider), IBlockRepository
{
    public IQueryable<FormBlocks> Get(BlockQueryOptions queryQueryOptions, CancellationToken cancellationToken = default)
    {
        var query = GetQueryableSet();
        if (queryQueryOptions.VersionId != Guid.Empty)
        {
            query = query.Where(t => t.VersionId == queryQueryOptions.VersionId);
        } 
        
        if (queryQueryOptions.AsNoTracking)
        {
            query = query.AsNoTracking();
        }
        
        if (queryQueryOptions.IncludeElement)
        {
            query = query.Include(x => x.Element);
        }

        if (queryQueryOptions.IncludeSchema)
        {
            query = query.Include(x => x.Schema);
        }

        return query;
    }
}
