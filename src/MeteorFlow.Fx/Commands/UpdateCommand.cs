using AutoMapper;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Fx.Commands;

public class UpdateCommand<TEntity, TKey>(TEntity entity) : ICommand<TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public TEntity Entity { get; set; } = entity;
}


internal class UpdateCommandHandler<TEntity, TKey>(IServices<TEntity, TKey> service) : ICommandHandler<UpdateCommand<TEntity, TKey>, TEntity>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    public Task<TEntity> HandleAsync(UpdateCommand<TEntity, TKey> command, CancellationToken cancellationToken = default)
    {
        return service.UpdateAsync(command.Entity, cancellationToken);
    }
}