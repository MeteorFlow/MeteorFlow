using System.Reflection;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Fx;

public static class ServiceCollections
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IServices<,>), typeof(Services<,>));
        // services.AddCommandHandlers(Assembly.GetExecutingAssembly()).AddQueryHandlers(Assembly.GetExecutingAssembly());
        return services;
    }

    public static IServiceCollection AddCommandHandlers(this IServiceCollection services, Assembly assembly)
    {
        var scanType = typeof(ICommandHandler<,>);

        RegisterScanTypeWithImplementations(services, assembly, scanType);

        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        return services;
    }

    public static IServiceCollection AddQueryHandlers(this IServiceCollection services, Assembly assembly)
    {
        var scanType = typeof(IQueryHandler<,>);

        RegisterScanTypeWithImplementations(services, assembly, scanType);
        
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        return services;
    }

    private static void RegisterScanTypeWithImplementations(IServiceCollection collection, Assembly assembly,
        Type scanType)
    {
        var commandHandlers = ScanTypes(assembly, scanType);

        foreach (var handler in commandHandlers)
        {
            var abstraction = handler.GetTypeInfo().ImplementedInterfaces
                .First(type => type.IsGenericType && type.GetGenericTypeDefinition() == scanType);
            collection.AddScoped(abstraction, handler);
        }
    }

    private static IEnumerable<Type> ScanTypes(Assembly assembly, Type typeToScanFor)
    {
        return assembly.GetTypes().Where(type => type is
           {
               IsClass: true,
               IsAbstract: false
           } && type.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeToScanFor));
    }
}