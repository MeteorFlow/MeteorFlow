using System.Text;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Models;
using MeteorFlow.Auth.Providers;
using MeteorFlow.Auth.Services.Identity;
using MeteorFlow.Auth.Services.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UserStore = MeteorFlow.Auth.Services.UserStore;

namespace MeteorFlow.Auth;

public static class ServiceCollections
{
    public static IServiceCollection AddAuthServices(this IServiceCollection services)
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
        // services.AddDbContext<CoreDbContext>(options =>
        //     options.UseSqlServer(configuration.GetConnectionString(Constant.PersistenceDb),
        //         b => b.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        services.AddDbContext<CoreDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(Constant.PgDb),
                b => b.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        services.AddScoped<ICoreDbContext>(provider => provider.GetService<CoreDbContext>());
        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Jwt configuration starts here
        var jwtSettings = configuration
            .GetSection(nameof(JwtSettings))
            .Get<JwtSettings>();

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
        
        services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString(Constants.PersistenceDb),
                b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)), ServiceLifetime.Transient);
        
        services.AddScoped<IUserClaimsPrincipalFactory<User>, AppUserClaimsPrincipleFactory>();
        services.AddScoped<IUserStore<User>, UserStore>();

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
            .AddRoles<Role>()
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddUserStore<UserStore>()
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