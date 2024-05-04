using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Fx.Services;

public interface IServices<TEntity, TKey>
    where TEntity : Entity<TKey> where TKey : IEquatable<TKey>
{
    Task<List<TEntity>> GetAsync(CancellationToken cancellationToken = default);

    Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

    Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
}