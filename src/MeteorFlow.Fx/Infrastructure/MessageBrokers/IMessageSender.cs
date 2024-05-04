namespace MeteorFlow.Fx.Infrastructure.MessageBrokers;

public interface IMessageSender<T>
{
    Task SendAsync(T message, MetaData metaData = null, CancellationToken cancellationToken = default);
}
