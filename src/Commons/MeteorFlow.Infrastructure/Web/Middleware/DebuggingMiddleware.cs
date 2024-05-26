using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MeteorFlow.Infrastructure.Web.Middleware;

public class DebuggingMiddleware(RequestDelegate next, ILogger<DebuggingMiddleware> logger)
{
    private readonly ILogger<DebuggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        await next(context);
        var elapsedTime = stopwatch.Elapsed;

        // inspect the context here
        // if (context.Request.Path.HasValue && context.Request.Path.Value.Contains("oidc"))
        // {
        // }
    }
}
