using System.Net;
using System.Reflection;
using MeteorFlow.Infrastructure;
using MeteorFlow.Infrastructure.Caching;
using MeteorFlow.Infrastructure.Configurations;
using MeteorFlow.Infrastructure.Web;
using MeteorFlow.Infrastructure.Web.Authorization.Policies;
using MeteorFlow.Infrastructure.Web.Endpoints;
using MeteorFlow.Infrastructure.Web.ExceptionHandlers;
using MeteorFlow.Infrastructure.Web.Middleware;
using MeteorFlow.Web.Authorizations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Ocelot.Configuration.File;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfig();
builder.Configuration.Bind(config);

// Add configuration from app settings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddCoreModule(config);
builder.Services.AddCaches(config.Caching);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = config.AuthenticationServer.Authority;
        options.Audience = config.AuthenticationServer.ApiName;
        options.RequireHttpsMetadata = config.AuthenticationServer.RequireHttpsMetadata;
    });

builder.Services.AddAuthorizationPolicies(Assembly.GetExecutingAssembly(), AuthorizationPolicyNames.GetPolicyNames());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins", b => b
        .WithOrigins(config.Cors.AllowedOrigins)
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowAnyHeader()
        .AllowCredentials());
    options.AddPolicy("AllowHeaders", b =>
    {
        b.WithOrigins(config.Cors.AllowedOrigins)
            .WithHeaders(HeaderNames.ContentType, HeaderNames.Server, HeaderNames.AccessControlAllowHeaders,
                HeaderNames.AccessControlExposeHeaders, "x-custom-header", "x-path", "x-record-in-use",
                HeaderNames.ContentDisposition);
    });
});

// Add controllers
builder.Services
    .ConfigRouting()
    .AddControllers()
    .AddNewtonsoftJson();

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

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MeteorFlow", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config.Cors.AllowAnyOrigin ? "AllowAnyOrigin" : "AllowedOrigins"); // allow credentials

app.UseGlobalExceptionHandlerMiddleware();
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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();
await app.UseOcelot();

app.Run();