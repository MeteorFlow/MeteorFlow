using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Infrastructure.Web.Endpoints;

public static class RoutingConfigEndpoint
{
    public static IServiceCollection ConfigRouting(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
        return services;
    }
}