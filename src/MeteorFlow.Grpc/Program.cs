using System.Reflection;
using System.Text;

using MeteorFlow.Grpc.Services;
using MeteorFlow.Infrastructure;
using MeteorFlow.Infrastructure.Caching;
using MeteorFlow.Infrastructure.Configurations;
using MeteorFlow.Infrastructure.Web.Authorization.Policies;
using MeteorFlow.Web.Authorizations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfig();
builder.Configuration.Bind(config);

// Add services to the container.
builder.Services.AddCoreModule(config);
builder.Services.AddCaches(config.Caching);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config.JwtSettings.Issuer,
        ValidAudience = config.JwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.JwtSettings.SecretKey))
    };
});

builder.Services.AddAuthorization();

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

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo { Title = "MeteorFlow gRPC", Version = "v1" });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
if (app.Environment.IsDevelopment()) {
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "gRPC V1");
    });
}

// Configure the HTTP request pipeline.
app.MapGrpcService<DefinitionMessageService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();