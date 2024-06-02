
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using MeteorFlow.Application;
using MeteorFlow.Auth.Authorization;
using MeteorFlow.Auth.PasswordValidators;
using MeteorFlow.Auth.Profiles;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Auth.Services;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Infrastructure.Configurations;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Infrastructure.Identity;
using MeteorFlow.Infrastructure.Web.Authorization.Policies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Role = MeteorFlow.Auth.Entities.Role;
using User = MeteorFlow.Auth.Entities.User;

namespace MeteorFlow.Auth;

public static class ServiceCollections
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, AppConfig appConfig)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddCrudService();
        services
            .AddDateTimeProvider()
            .AddUnitOfWork()
            .AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>()
            .AddScoped<IUserRoleRepository, UserRoleRepository>();

        var persistenceKey = appConfig.ConnectionStrings?.Postgres;
        
        if (persistenceKey is null)
        {
            throw new Exception("PersistenceKey cannot be null");
        }
        
        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(persistenceKey,
                b => b.MigrationsAssembly(typeof(AuthDbContext).Assembly.FullName))
                .UseSnakeCaseNamingConvention(), ServiceLifetime.Transient);
        
        services.AddScoped<IUserClaimsPrincipalFactory<User>, AppUserClaimsPrincipleFactory>();
        services.AddScoped<IUserStore<User>, AuthUserStore>();
        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ICurrentUser, CurrentWebUser>();

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
            .AddUserStore<AuthUserStore>()
            .AddRoleStore<AuthRoleStore>()
            .AddDefaultTokenProviders()
            .AddUserManager<AuthUserManager>();
        
        services.AddTransient<IUserStore<User>, AuthUserStore>();
        services.AddTransient<IRoleStore<Role>, AuthRoleStore>();
        
        services.AddCommandHandlers(Assembly.GetExecutingAssembly());
        services.AddQueryHandlers(Assembly.GetExecutingAssembly());
        
        return services;
    }
    
    private static void ConfigureAuthOptions(this IServiceCollection services)
    {
        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromHours(3);
        });

        services.Configure<EmailConfirmationTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromDays(2);
        });

        services.Configure<IdentityOptions>(options =>
        {
            options.Tokens.EmailConfirmationTokenProvider = "EmailConfirmation";

            // Default Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        });

        services.Configure<PasswordHasherOptions>(option =>
        {
            // option.IterationCount = 10000;
            // option.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
        });

        services.AddAuthorizationPolicies(Assembly.GetExecutingAssembly(), AuthorizationPolicyNames.GetPolicyNames());
    }
    
    private static IdentityBuilder AddTokenProviders(this IdentityBuilder identityBuilder)
    {
        identityBuilder
            .AddDefaultTokenProviders()
            .AddTokenProvider<EmailConfirmationTokenProvider<User>>("EmailConfirmation");

        return identityBuilder;
    }

    private static IdentityBuilder AddPasswordValidators(this IdentityBuilder identityBuilder)
    {
        identityBuilder
            .AddPasswordValidator<WeakPasswordValidator>()
            .AddPasswordValidator<HistoricalPasswordValidator>();

        return identityBuilder;
    }

    public static IServiceCollection AddNativeAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration
            .GetSection(nameof(JwtSettings))
            .Get<JwtSettings>();
        
        services.AddSingleton<SecurityTokenHandler, JwtSecurityTokenHandler>();
            
        services.ConfigureAuthOptions();
        return services;
    }
    
    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork), provider => provider.GetRequiredService<AuthDbContext>());
        return services;
    }
}