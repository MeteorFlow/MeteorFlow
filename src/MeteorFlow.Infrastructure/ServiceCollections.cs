using MeteorFlow.Core;
using MeteorFlow.Fx;
using MeteorFlow.Infrastructure.Configurations;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Infrastructure.Persistence;
using MeteorFlow.Infrastructure.Repositories;
using MeteorFlow.Infrastructure.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MeteorFlow.Infrastructure;

public static class ServiceCollections
{
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
            )
            .UseSnakeCaseNamingConvention()
        );

        return services;
    }

    public static IServiceCollection AddCoreModule(this IServiceCollection services, AppConfig appConfig)
    {
        services
            .AddDateTimeProvider()
            .AddPersistence(appConfig.ConnectionStrings)
            .AddUnitOfWork()
            .AddCoreRepositories()
            .AddApplicationServices();

        services.AddCoreServices();
        return services;
    }
}