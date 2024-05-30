using System.Net;
using MeteorFlow.Web.Configurations;
using Microsoft.Net.Http.Headers;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


// Add configuration from app settings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json")
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json")
    .AddEnvironmentVariables();
var config = new AppConfig();
builder.Configuration.Bind(config);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowedOrigins",
        b =>
            b.WithOrigins(config.Cors.AllowedOrigins)
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowAnyHeader()
                .AllowCredentials()
    );
    options.AddPolicy(
        "AllowHeaders",
        b =>
        {
            b.WithOrigins(config.Cors.AllowedOrigins)
                .WithHeaders(
                    HeaderNames.ContentType,
                    HeaderNames.Server,
                    HeaderNames.AccessControlAllowHeaders,
                    HeaderNames.AccessControlExposeHeaders,
                    "x-custom-header",
                    "x-path",
                    "x-record-in-use",
                    HeaderNames.ContentDisposition
                );
        }
    );
});
    
builder.Services.AddOcelot(builder.Configuration);

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

app.UseCors("AllowedOrigins");

app.UseWebSockets();
await app.UseOcelot();

app.Run();
