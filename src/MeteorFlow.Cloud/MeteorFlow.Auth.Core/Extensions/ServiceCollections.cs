using System.Text;
using MeteorFlow.Auth.Core.Entities;
using MeteorFlow.Auth.Core.Models;
using MeteorFlow.Auth.Core.Persistence;
using MeteorFlow.Auth.Core.Providers;
using MeteorFlow.Auth.Core.Services.Identity;
using MeteorFlow.Auth.Core.Services.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MeteorFlow.Auth.Core.Extensions;

public static class ServiceCollections
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
    {
        // Configure and register your core services here
        // services.AddTransient<IMyService, MyService>();

        // You can also configure services using the configuration parameter
        // var someConfigValue = configuration.GetValue<string>("SomeConfigKey");
        // services.AddSingleton(new MyConfigService(someConfigValue));
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }

    public static IServiceCollection AddMeteorFlowAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddNativeAuthentication(configuration);

        return services;
    }
    
    private static IServiceCollection AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {
        var persistenceKey = configuration.GetConnectionString(Constants.PersistenceDb);
        
        if (persistenceKey is null || persistenceKey == "")
        {
            throw new Exception("PersistenceKey cannot be null");
        }
        
        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(Constants.PersistenceDb),
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)), ServiceLifetime.Transient);
        
        services.AddScoped<IIdentityContext>(provider => provider.GetService<IdentityContext>());
        services.AddScoped<IUserClaimsPrincipalFactory<User>, AppUserClaimsPrincipleFactory>();
        services.AddScoped<IUserStore<User>, IdentityStore>();

        services
            .AddIdentityCore<User>(options =>
            {
                options.User.AllowedUserNameCharacters = Constants.AllowedUserNameCharacters;
                options.User.RequireUniqueEmail = false;

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<Roles>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddUserStore<IdentityStore>()
            .AddUserManager<IdentityManager>();
        
        return services;
    }
    
    private static IServiceCollection AddNativeAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration
            .GetSection(nameof(JwtSettings))
            .Get<JwtSettings>();

        if (jwtSettings == null) throw new Exception("JwtSettings is null");

        services.AddIdentityContext(configuration);
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

        return services;
    }



    public static IServiceCollection AddAuthorizations(this IServiceCollection services)
    {
        
        return services;
    }
}