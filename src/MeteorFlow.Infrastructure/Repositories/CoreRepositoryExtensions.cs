using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Infrastructure.Repositories;

public static class RepositoryExtensions
{
    public static IServiceCollection AddCoreRepositories(this IServiceCollection services)
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

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork), provider => provider.GetRequiredService<CoreDbContext>());
        return services;
    }
}