using System.Reflection;
using MeteorFlow.Application;
using MeteorFlow.FormBuilder.Profiles;
using MeteorFlow.FormBuilder.Repositories;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Infrastructure.Configurations;
using MeteorFlow.Infrastructure.DateTimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.FormBuilder;

public static class ServiceCollections
{
    public static IServiceCollection AddFormBuilderModule(this IServiceCollection services, AppConfig appConfig)
    {
        services.AddDateTimeProvider();
        services.AddAutoMapper(typeof(AutoMapperProfile));

        
        var persistenceKey = appConfig.ConnectionStrings?.Postgres;
        
        if (persistenceKey is null or "")
        {
            throw new Exception("PersistenceKey cannot be null");
        }
        
        services.AddDbContext<FormDbContext>(options =>
            options.UseNpgsql(persistenceKey,
                b => b.MigrationsAssembly(typeof(FormDbContext).Assembly.FullName))
                .UseSnakeCaseNamingConvention(), 
            ServiceLifetime.Transient);

        services
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddUnitOfWork()
            .AddScoped<IBlockRepository, BlockRepository>()
            .AddScoped<IElementRepository, ElementRepository>()
            .AddScoped<ISchemaRepository, SchemaRepository>();
        services.AddCrudService();
        services.AddCommandHandlers(Assembly.GetExecutingAssembly());
        services.AddQueryHandlers(Assembly.GetExecutingAssembly());
        return services;
    }
    
    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork), provider => provider.GetRequiredService<FormDbContext>());
        return services;
    }
}