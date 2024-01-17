using MeteorFlow.Core.Services.AppSettings;
using MeteorFlow.Core.Services.Metadata;
using MeteorFlow.Core.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Core.Extensions;

public static class ServiceCollections
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Configure and register your core services here
        // services.AddTransient<IMyService, MyService>();
        services.AddScoped<IAppSettingsService, AppSettingsService>();

        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IUsersService, UsersService>();

        services.AddScoped<IMetadataService, MetadataService>();

        // You can also configure services using the configuration parameter
        // var someConfigValue = configuration.GetValue<string>("SomeConfigKey");
        // services.AddSingleton(new MyConfigService(someConfigValue));
        services.AddAutoMapper(typeof(AutoMapperProfile));
        return services;
    }
}