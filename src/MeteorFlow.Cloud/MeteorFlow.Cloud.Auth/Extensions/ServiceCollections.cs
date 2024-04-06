using System.Text;
using MeteorFlow.Cloud.Auth.Persistence;
using MeteorFlow.Cloud.Auth.Providers;
using MeteorFlow.Cloud.Auth.Services.Identity;
using MeteorFlow.Cloud.Auth.Services.Jwt;
using MeteorFlow.Core.Fx.Identities;
using MeteorFlow.Infrastructure.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MeteorFlow.Cloud.Auth.Extensions;

public static class ServiceCollections
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Configure and register your core services here
        // services.AddTransient<IMyService, MyService>();

        // You can also configure services using the configuration parameter
        // var someConfigValue = configuration.GetValue<string>("SomeConfigKey");
        // services.AddSingleton(new MyConfigService(someConfigValue));
        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Jwt configuration starts here
        var jwtSettings = configuration
            .GetSection(nameof(JwtSettings))
            .Get<JwtSettings>();
        
        if (jwtSettings == null) throw new Exception("JwtSettings is null");

        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserClaimsPrincipalFactory<IdentityBase>, AppUserClaimsPrincipleFactory>();
        services.AddScoped<IUserStore<IdentityBase>, IdentityStore>();
        services.AddScoped<IIdentityService, IdentityService>();

        services
            .AddIdentityCore<IdentityBase>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";
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
}