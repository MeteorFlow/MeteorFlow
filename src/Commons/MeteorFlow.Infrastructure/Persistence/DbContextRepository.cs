using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Infrastructure.Persistence;

public class DbContextRepository<TDbContext, TEntity, TKey>(TDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
    where TDbContext : DbContext, IUnitOfWork
{
    protected DbSet<TEntity> DbSet => dbContext.Set<TEntity>();

    public IUnitOfWork UnitOfWork => dbContext;

    public async Task AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id.Equals(default(TKey)))
        {
            await AddAsync(entity, cancellationToken);
        }
        else
        {
            await UpdateAsync(entity, cancellationToken);
        }
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedDate = dateTimeProvider.OffsetUtcNow;
        var result = await DbSet.AddAsync(entity, cancellationToken);
        return result.Entity;
    }

    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.LastModifiedDate = dateTimeProvider.OffsetUtcNow;
        DbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public IQueryable<TEntity> GetQueryableSet()
    {
        return dbContext.Set<TEntity>();
    }

    public Task<T1> FirstOrDefaultAsync<T1>(IQueryable<T1> query)
    {
        return query.FirstOrDefaultAsync();
    }

    public Task<T1> SingleOrDefaultAsync<T1>(IQueryable<T1> query)
    {
        return query.SingleOrDefaultAsync();
    }

    public Task<List<T1>> ToListAsync<T1>(IQueryable<T1> query)
    {
        return query.ToListAsync();
    }

    public void SetRowVersion(TEntity entity, byte[] version)
    {
        dbContext.Entry(entity).OriginalValues[nameof(entity.RowVersion)] = version;
    }

    public bool IsDbUpdateConcurrencyException(Exception ex)
    {
        return ex is DbUpdateConcurrencyException;
    }
}