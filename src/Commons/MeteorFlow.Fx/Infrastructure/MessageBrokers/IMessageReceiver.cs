namespace MeteorFlow.Fx.Infrastructure.MessageBrokers;

public interface IMessageReceiver<TConsumer, T>
{
    Task ReceiveAsync(Func<T, MetaData, Task> action, CancellationToken cancellationToken);
}
