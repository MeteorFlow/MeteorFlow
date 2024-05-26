using MeteorFlow.Application.Crud;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Application.Commands;

public class DeleteCommand<TEntity, TKey>(TEntity entity) : ICommand<TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public TEntity Entity { get; set; } = entity;
}

internal class DeleteCommandHandler<TEntity, TKey>(IServices<TEntity, TKey> service) : ICommandHandler<DeleteCommand<TEntity, TKey>, TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public Task<TEntity> HandleAsync(DeleteCommand<TEntity, TKey> command, CancellationToken cancellationToken = default)
    {
        return service.DeleteAsync(command.Entity, cancellationToken);
    }
}