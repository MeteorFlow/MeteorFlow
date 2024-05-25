using System.Net;
using MeteorFlow.Web.Configurations;
using Ocelot.Configuration.File;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfig();
builder.Configuration.Bind(config);

builder.Services.AddOcelot(builder.Configuration);
builder.Services.PostConfigure<FileConfiguration>(fileConfiguration =>
{
    foreach (var route in config.Ocelot.Routes.Select(x => x.Value))
    {
        var uri = new Uri(route.Downstream);

        foreach (var pathTemplate in route.UpstreamPathTemplates)
        {
            fileConfiguration.Routes.Add(new FileRoute
            {
                UpstreamPathTemplate = pathTemplate,
                DownstreamPathTemplate = pathTemplate,
                DownstreamScheme = uri.Scheme,
                DownstreamHostAndPorts = new List<FileHostAndPort>
                {
                    new FileHostAndPort { Host = uri.Host, Port = uri.Port }
                }
            });
        }
    }

    foreach (var route in fileConfiguration.Routes)
    {
        if (string.IsNullOrWhiteSpace(route.DownstreamScheme))
        {
            route.DownstreamScheme = config?.Ocelot?.DefaultDownstreamScheme;
        }

        if (string.IsNullOrWhiteSpace(route.DownstreamPathTemplate))
        {
            route.DownstreamPathTemplate = route.UpstreamPathTemplate;
        }
    }
});

var app = builder.Build();

app.UseStatusCodePages(context =>
{
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;
    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        response.Redirect($"{request.Scheme}://{request.Host}/api/auth?returnUrl={request.Path}"); //redirect to the login page.
    }

    return Task.CompletedTask;
});

app.UseWebSockets();
await app.UseOcelot();

app.Run();