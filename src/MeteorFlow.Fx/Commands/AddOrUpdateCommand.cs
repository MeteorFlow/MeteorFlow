using AutoMapper;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Fx.Commands;

public class AddOrUpdateCommand<TEntity, TKey>(TEntity entity) : ICommand<TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public TEntity Entity { get; set; } = entity;
}

internal class AddOrUpdateCommandHandler<TEntity, TKey>(IServices<TEntity, TKey> service) : ICommandHandler<AddOrUpdateCommand<TEntity, TKey>, TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public Task<TEntity> HandleAsync(AddOrUpdateCommand<TEntity, TKey> command, CancellationToken cancellationToken = default)
    {
        return service.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}