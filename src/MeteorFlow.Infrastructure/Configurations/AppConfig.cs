using MeteorFlow.Infrastructure.Caching;
using MeteorFlow.Web.Configs;

namespace MeteorFlow.Infrastructure.Configurations;

public class AppConfig
{
    public string AllowedHosts { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
    
    public CachingOptions Caching { get; set; }
    
    public Cors Cors { get; set; }
    
    public AuthenticationServer AuthenticationServer { get; set; }
    
    public OcelotOptions Ocelot { get; set; }
    
    public JwtSettings JwtSettings { get; set; }
}

public class AuthenticationServer
{
    public string Authority { get; set; }
    public string ApiName { get; set; }
    public bool RequireHttpsMetadata { get; set; }
}

public class ConnectionStrings
{
    public string Postgres { get; init; } = string.Empty;
}

public class Cors
{
    public bool AllowAnyOrigin { get; set; }

    public string[] AllowedOrigins { get; set; }
}

public class JwtSettings
{
    public required string SecretKey { get; set; }
    public required string EncryptKey { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int NotBeforeMinutes { get; set; }
    public int ExpirationMinutes { get; set; }
}