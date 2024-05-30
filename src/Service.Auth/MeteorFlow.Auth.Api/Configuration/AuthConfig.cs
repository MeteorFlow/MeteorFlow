using ClassifiedAds.Services.Identity.IdentityProviders.Auth0;
using ClassifiedAds.Services.Identity.IdentityProviders.Azure;
using MeteorFlow.Infrastructure.Configurations;

namespace Meteor.Auth.Api.Configuration;

public class AuthConfig: AppConfig
{
    public GithubOptions Github { get; set; }
    public IdentityProvidersOptions Providers { get; set; }
}

public class IdentityProvidersOptions
{
    public Auth0Options Auth0 { get; set; }

    public AzureAdB2COptions AzureActiveDirectoryB2C { get; set; }
}

public class GithubOptions
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}