using System.Reflection;
using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Handlers;
using MeteorFlow.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Application;

public static class ApplicationServiceCollections
{
    public static IServiceCollection AddCrudService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IServices<,>), typeof(Services<,>));
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