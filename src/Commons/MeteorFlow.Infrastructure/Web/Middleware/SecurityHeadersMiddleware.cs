using Microsoft.AspNetCore.Http;

namespace MeteorFlow.Infrastructure.Web.Middleware;

public class SecurityHeadersMiddleware(RequestDelegate next, Dictionary<string, string> headers)
{
    public async Task Invoke(HttpContext context)
    {
        foreach (var header in headers)
        {
            context.Response.Headers[header.Key] = header.Value;
        }

        await next(context);
    }
}
