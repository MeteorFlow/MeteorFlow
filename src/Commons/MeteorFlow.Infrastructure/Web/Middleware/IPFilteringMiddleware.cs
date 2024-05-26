using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MeteorFlow.Infrastructure.Web.Middleware;

public class IpFilteringMiddleware(RequestDelegate next, ILogger<IpFilteringMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var remoteIp = context.Connection.RemoteIpAddress;
        logger.LogInformation($"Request from Remote IP address: {remoteIp}");

        await next(context);
    }
}
