using MeteorFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Infrastructure;

public static class ServiceCollections
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        
        services.AddDbContext<CoreDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(Constant.PersistenceDb),
                b => b.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        // services.AddDbContext<CoreDbContext>(options =>
        //     options.UseNpgsql(configuration.GetConnectionString(Constant.PgDb),
        //         b => b.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        // services.AddScoped<ICoreDbContext>(provider => provider.GetService<CoreDbContext>());
        return services;
    }
}