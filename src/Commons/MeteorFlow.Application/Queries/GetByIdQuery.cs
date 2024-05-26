using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Repositories;

namespace MeteorFlow.Application.Queries;

public abstract class GetByIdQuery<TEntity, TKey> : IQuery<TEntity>
    where TEntity : Entity<TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; set; }
    public bool ThrowNotFoundIfNull { get; set; }
}

internal class GetByIdQueryHandler<TEntity, TKey>(IRepository<TEntity, TKey> repository)
    : IQueryHandler<GetByIdQuery<TEntity, TKey>, TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public Task<TEntity> HandleAsync(GetByIdQuery<TEntity, TKey> query, CancellationToken cancellationToken = default)
    {
        return repository.FirstOrDefaultAsync(repository.GetQueryableSet().Where(x => x.Id.Equals(query.Id) ));
    }
}
