using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Fx.Commands;

public class AddCommand<TEntity, TKey>(TEntity entity) : ICommand<TEntity>
    where TEntity : Entity<TKey>
{
    public TEntity Entity { get; set; } = entity;
}

internal class AddCommandHandler<TEntity, TKey>(IServices<TEntity, TKey> service) : ICommandHandler<AddCommand<TEntity, TKey>, TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public Task<TEntity> HandleAsync(AddCommand<TEntity, TKey> command, CancellationToken cancellationToken = default)
    {
        return service.AddAsync(command.Entity, cancellationToken);
    }
}
