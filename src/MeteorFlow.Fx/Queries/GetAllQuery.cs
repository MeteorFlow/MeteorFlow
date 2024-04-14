using AutoMapper;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Repositories;

namespace MeteorFlow.Fx.Queries;

public class GetAllQuery<TEntity, TKey> : IQuery<List<TEntity>>
     where TEntity : Entity<TKey> where TKey : IEquatable<TKey>;

internal class GetEntitiesQueryHandler<TEntity, TKey>(IRepository<TEntity, TKey> repository)
    : IQueryHandler<GetAllQuery<TEntity, TKey>, List<TEntity>>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public Task<List<TEntity>> HandleAsync(GetAllQuery<TEntity, TKey> query, CancellationToken cancellationToken = default)
    {
        return repository.ToListAsync(repository.GetQueryableSet());
    }
}
