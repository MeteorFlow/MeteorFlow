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
        return services;
    }

    public static IServiceCollection AddApplicationHandlers(this IServiceCollection services)
    {
        services.AddSingleton(typeof(ICommandDispatcher<,>), typeof(CommandDispatcher<,>));
        services.AddSingleton(typeof(IQueryDispatcher), typeof(QueryDispatcher));

        services
            .AddTransient(typeof(ICommandHandler<,>), typeof(AddOrUpdateCommandHandler<,>))
            .AddTransient(typeof(ICommandHandler<,>), typeof(AddCommandHandler<,>))
            .AddTransient(typeof(ICommandHandler<,>), typeof(DeleteCommandHandler<,>))
            .AddTransient(typeof(ICommandHandler<,>), typeof(UpdateCommandHandler<,>));
        
        services
            .AddTransient(typeof(IQueryHandler<,>), typeof(GetEntitiesQueryHandler<,>))
            .AddTransient(typeof(IQueryHandler<,>), typeof(GetByIdQueryHandler<,>));
        
        return services;
    }
}