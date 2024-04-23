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
        // Configure and register your core services here
        // services.AddTransient<IMyService, MyService>();

        // You can also configure services using the configuration parameter
        // var someConfigValue = configuration.GetValue<string>("SomeConfigKey");
        // services.AddSingleton(new MyConfigService(someConfigValue));
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddCommandHandlers(Assembly.GetExecutingAssembly()).AddQueryHandlers(Assembly.GetExecutingAssembly());
        return services;
    }
}