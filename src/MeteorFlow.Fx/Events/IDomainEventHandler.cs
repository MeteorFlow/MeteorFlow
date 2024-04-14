
namespace MeteorFlow.Fx.Events;

public interface IDomainEventHandler<in T>
       where T : IDomainEvent
{
    Task HandleAsync(T domainEvent, CancellationToken cancellationToken = default);
}
