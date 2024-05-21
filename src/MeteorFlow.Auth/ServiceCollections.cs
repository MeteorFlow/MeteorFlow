using System.Reflection;
using System.Text;
using MeteorFlow.Auth.Authorization;
using MeteorFlow.Auth.Models;
using MeteorFlow.Auth.PasswordValidators;
using MeteorFlow.Auth.Profiles;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Auth.Services;
using MeteorFlow.Infrastructure.Web.Authorization.Policies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Role = MeteorFlow.Auth.Entities.Role;
using User = MeteorFlow.Auth.Entities.User;

namespace MeteorFlow.Auth;

public static class ServiceCollections
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRoleRepository, RoleRepository>();
        
        var persistenceKey = configuration.GetConnectionString(Constants.PersistenceDb);
        
        if (persistenceKey is null || persistenceKey == "")
        {
            throw new Exception("PersistenceKey cannot be null");
        }
        
        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(persistenceKey,
                b => b.MigrationsAssembly(typeof(AuthDbContext).Assembly.FullName)), ServiceLifetime.Transient);
        
        services.AddScoped<IUserClaimsPrincipalFactory<User>, AppUserClaimsPrincipleFactory>();
        services.AddScoped<IUserStore<User>, AuthUserStore>();

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

        if (jwtSettings == null) throw new Exception("JwtSettings is null");

        services.AddAuthModule(configuration);
        
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
            })
            .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"), "AzureAD");
            
        services.ConfigureAuthOptions();
        return services;
    }
}