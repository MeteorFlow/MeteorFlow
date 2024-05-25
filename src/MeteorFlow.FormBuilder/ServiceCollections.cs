using System.Reflection;
using MeteorFlow.Core;
using MeteorFlow.Core.Profiles;
using MeteorFlow.FormBuilder.Repositories;
using MeteorFlow.Fx;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.FormBuilder;

public static class ServiceCollections
{
    public static IServiceCollection AddFormBuilderModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCoreServices();
        services.AddApplicationServices().AddDateTimeProvider();
        
        services.AddAutoMapper(typeof(AutoMapperProfile));
        var persistenceKey = configuration.GetConnectionString(Constants.PersistenceDb);
        
        if (persistenceKey is null or "")
        {
            throw new Exception("PersistenceKey cannot be null");
        }
        
        services.AddDbContext<FormDbContext>(options =>
            options.UseNpgsql(persistenceKey,
                b => b.MigrationsAssembly(typeof(FormDbContext).Assembly.FullName))
                .UseSnakeCaseNamingConvention(), ServiceLifetime.Transient);

        services.AddScoped<IBlockRepository, BlockRepository>()
            .AddScoped<IElementRepository, ElementRepository>()
            .AddScoped<ISchemaRepository, SchemaRepository>();
        return services;
    }
}