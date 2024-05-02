using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MeteorFlow.Infrastructure.Web.Middleware;

public class LoggingStatusCodeMiddleware(RequestDelegate next, ILogger<LoggingStatusCodeMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        await next(context);

        var statusCode = context.Response.StatusCode;
        var path = context.Request.Path;
        var method = context.Request.Method;
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? context.User.FindFirst("sub")?.Value;
        var remoteIp = context.Connection.RemoteIpAddress;

        var statusCodes = new[] { StatusCodes.Status401Unauthorized, StatusCodes.Status403Forbidden };

        if (statusCodes.Contains(statusCode))
        {
            logger.LogWarning($"StatusCode: {statusCode}, UserId: {ReplaceCRLF(userId)}, Path: {ReplaceCRLF(path)}, Method: {ReplaceCRLF(method)}, IP: {remoteIp}");
        }
    }

    private static string ReplaceCRLF(string text)
    {
        return text?.Replace("\r", "\\r").Replace("\n", "\\n");
    }
}
