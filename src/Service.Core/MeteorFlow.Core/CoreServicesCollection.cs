using System.Reflection;
using MeteorFlow.Application;
using MeteorFlow.Core.Profiles;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Infrastructure.Configurations;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MeteorFlow.Core;

public static class CoreServicesCollection
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services, AppConfig appConfig)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services
            .AddDateTimeProvider()
            .AddPersistence(appConfig.ConnectionStrings)
            .AddUnitOfWork()
            .AddCoreRepositories();
        services.AddCommandHandlers(Assembly.GetExecutingAssembly());
        services.AddQueryHandlers(Assembly.GetExecutingAssembly());
        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ICurrentUser, CurrentWebUser>();

        services.AddCrudService();
        return services;
    }
    
    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        ConnectionStrings conn
    )
    {
        if (conn.Postgres.IsNullOrEmpty())
        {
            throw new ArgumentNullException(nameof(conn.Postgres));
        }

        services.AddDbContext<CoreDbContext>(options => options
            .UseNpgsql(
                conn.Postgres,
                builder => builder
                    .MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName)
            ).UseSnakeCaseNamingConvention()
        );

        return services;
    }
    
    private static IServiceCollection AddCoreRepositories(this IServiceCollection services)
    {
        services
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddScoped(typeof(IDefinitionRepository), typeof(DefinitionRepository))
            .AddScoped(typeof(IInstanceRepository), typeof(InstanceRepository))
            .AddScoped(typeof(ISettingRepository), typeof(SettingRepository))
            .AddScoped(typeof(IVersionControlRepository), typeof(VersionControlRepository));

        //
        // services.AddScoped<ILockManager, LockManager>();
        // services.AddScoped<ICircuitBreakerManager, CircuitBreakerManager>();

        return services;
    }
    
    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork), provider => provider.GetRequiredService<CoreDbContext>());
        return services;
    }
}

