using MeteorFlow.Core.Profiles;
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
        return services;
    }
}