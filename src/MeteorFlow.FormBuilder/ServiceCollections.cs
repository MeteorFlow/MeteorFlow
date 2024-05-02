using System.Reflection;
using MeteorFlow.Core.Profiles;
using MeteorFlow.Fx;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.FormBuilder;

public static class ServiceCollections
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