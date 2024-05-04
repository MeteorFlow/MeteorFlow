﻿namespace MeteorFlow.Fx.Infrastructure.MessageBrokers;

public interface IMessageBusConsumer<TConsumer, T>
{
    Task HandleAsync(T data, MetaData metaData, CancellationToken cancellationToken = default);
}
