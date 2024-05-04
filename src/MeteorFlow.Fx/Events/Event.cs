using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Fx.Events;

public abstract class Event<TEntity, TKey> : IDomainEvent
    where TEntity : Base<TKey> where TKey : IEquatable<TKey>
{
    public TEntity Entity { get; init; }
    public DateTime EventDateTime { get; init; }
}
public class EntityCreatedEvent<TEntity, TKey> : Event<TEntity, TKey>
    where TEntity : Base<TKey> where TKey : IEquatable<TKey>;

public class EntityUpdatedEvent<TEntity, TKey> : Event<TEntity, TKey>
    where TEntity : Base<TKey> where TKey : IEquatable<TKey>;

public class EntityDeletedEvent<TEntity, TKey> : Event<TEntity, TKey>
    where TEntity : Base<TKey> where TKey : IEquatable<TKey>;