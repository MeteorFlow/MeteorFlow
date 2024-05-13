using System.Reflection;
using MeteorFlow.Core.Profiles;
using MeteorFlow.Fx;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Core;

public static class CoreServiceCollections
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddApplicationServices();
        services.AddCommandHandlers(Assembly.GetExecutingAssembly()).AddQueryHandlers(Assembly.GetExecutingAssembly());
        return services;
    }
}