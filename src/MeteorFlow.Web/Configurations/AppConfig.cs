namespace MeteorFlow.Web.Configurations;

public class AppConfig
{
    public ConnectionStrings ConnectionStrings { get; set; }

    // public LoggingOptions Logging { get; set; }
    //
    // public CachingOptions Caching { get; set; }
    //
    // public MonitoringOptions Monitoring { get; set; }

    public IdentityServerAuthentication IdentityServerAuthentication { get; set; }

    // public NotificationOptions Notification { get; set; }
    //
    // public InterceptorsOptions Interceptors { get; set; }
    //
    // public IdentityProvidersOptions Providers { get; set; }
}

public class ConnectionStrings
{
    public string ClassifiedAds { get; set; }

    public string MigrationsAssembly { get; set; }
}

public class IdentityServerAuthentication
{
    public string Provider { get; set; }

    public string Authority { get; set; }

    public string ApiName { get; set; }

    public bool RequireHttpsMetadata { get; set; }

    public OpenIddictOptions OpenIddict { get; set; }
}

public class OpenIddictOptions
{
    public string IssuerUri { get; set; }

    // public CertificateOption TokenDecryptionCertificate { get; set; }
    //
    // public CertificateOption IssuerSigningCertificate { get; set; }
}