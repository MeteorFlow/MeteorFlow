using MeteorFlow.Core.Extensions;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Infrastructure.Extensions;

public static class ServiceCollections
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Configure and register your core services here
        // services.AddTransient<IMyService, MyService>();

        // You can also configure services using the configuration parameter
        // var someConfigValue = configuration.GetValue<string>("SomeConfigKey");
        // services.AddSingleton(new MyConfigService(someConfigValue));
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CoreDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(Constant.PersistenceDb),
                b => b.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        // services.AddDbContext<CoreDbContext>(options =>
        //     options.UseNpgsql(configuration.GetConnectionString(Constant.PgDb),
        //         b => b.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        services.AddScoped<ICoreDbContext>(provider => provider.GetService<CoreDbContext>());
        return services;
    }
}