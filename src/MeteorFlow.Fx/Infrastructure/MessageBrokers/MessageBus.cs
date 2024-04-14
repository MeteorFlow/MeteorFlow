﻿using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Fx.Infrastructure.MessageBrokers;

public class MessageBus(IServiceProvider serviceProvider) : IMessageBus
{
    private static readonly List<Type> Consumers = [];
    private static readonly Dictionary<string, List<Type>> OutboxEventHandlers = new();

    internal static void AddConsumers(Assembly assembly, IServiceCollection services)
    {
        var types = assembly.GetTypes()
                            .Where(x => x.GetInterfaces().Any(y => y.IsGenericType && y.GetGenericTypeDefinition() == typeof(IMessageBusConsumer<,>)))
                            .ToList();

        foreach (var type in types)
        {
            services.AddTransient(type);
        }

        Consumers.AddRange(types);
    }

    internal static void AddOutboxEventPublishers(Assembly assembly, IServiceCollection services)
    {
        var types = assembly.GetTypes()
                            .Where(x => x.GetInterfaces().Any(y => y == typeof(IOutBoxEventPublisher)))
                            .ToList();

        foreach (var type in types)
        {
            services.AddTransient(type);
        }

        foreach (var item in types)
        {
            var canHandlerEventTypes = (string[])item.InvokeMember(nameof(IOutBoxEventPublisher.CanHandleEventTypes), BindingFlags.InvokeMethod, null, null, null, CultureInfo.CurrentCulture) ?? [];
            var eventSource = (string)item.InvokeMember(nameof(IOutBoxEventPublisher.CanHandleEventSource), BindingFlags.InvokeMethod, null, null, null, CultureInfo.CurrentCulture);

            foreach (var eventType in canHandlerEventTypes)
            {
                var key = eventSource + ":" + eventType;
                if (!OutboxEventHandlers.ContainsKey(key))
                {
                    OutboxEventHandlers[key] = new List<Type>();
                }

                OutboxEventHandlers[key].Add(item);
            }
        }
    }

    public async Task SendAsync<T>(T message, MetaData metaData = null, CancellationToken cancellationToken = default)
        where T : IMessageBusMessage
    {
        await serviceProvider.GetRequiredService<IMessageSender<T>>().SendAsync(message, metaData, cancellationToken);
    }

    public async Task ReceiveAsync<TConsumer, T>(Func<T, MetaData, Task> action, CancellationToken cancellationToken = default)
        where T : IMessageBusMessage
    {
        await serviceProvider.GetRequiredService<IMessageReceiver<TConsumer, T>>().ReceiveAsync(action, cancellationToken);
    }

    public async Task ReceiveAsync<TConsumer, T>(CancellationToken cancellationToken = default)
        where T : IMessageBusMessage
    {
        await serviceProvider.GetRequiredService<IMessageReceiver<TConsumer, T>>().ReceiveAsync(async (data, metaData) =>
        {
            using var scope = serviceProvider.CreateScope();
            foreach (var handler in from handlerType in Consumers let canHandleEvent = handlerType.GetInterfaces()
                         .Any(x => x.IsGenericType
                                   && x.GetGenericTypeDefinition() == typeof(IMessageBusConsumer<,>)
                                   && x.GenericTypeArguments[0] == typeof(TConsumer) && x.GenericTypeArguments[1] == typeof(T)) where canHandleEvent select scope.ServiceProvider.GetService(handlerType))
            {
                await ((dynamic)handler).HandleAsync((dynamic)data, metaData, cancellationToken);
            }
        }, cancellationToken);
    }

    public async Task SendAsync(PublishingOutBoxEvent outbox, CancellationToken cancellationToken = default)
    {
        var key = outbox.EventSource + ":" + outbox.EventType;
        var handlerTypes = OutboxEventHandlers.ContainsKey(key) ? OutboxEventHandlers[key] : null;

        if (handlerTypes == null)
        {
            // TODO: Take Note
            return;
        }

        foreach (var type in handlerTypes)
        {
            dynamic handler = serviceProvider.GetService(type);
            await handler.HandleAsync(outbox, cancellationToken);
        }
    }
}

public static class MessageBusExtensions
{
    public static void AddMessageBusConsumers(this IServiceCollection services, Assembly assembly)
    {
        MessageBus.AddConsumers(assembly, services);
    }

    public static void AddOutboxEventPublishers(this IServiceCollection services, Assembly assembly)
    {
        MessageBus.AddOutboxEventPublishers(assembly, services);
    }

    public static void AddMessageBus(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IMessageBus, MessageBus>();
        services.AddMessageBusConsumers(assembly);
        services.AddOutboxEventPublishers(assembly);
    }
}