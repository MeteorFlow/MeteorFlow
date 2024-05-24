using System.Reflection;
using MeteorFlow.Core;
using MeteorFlow.Fx;
using MeteorFlow.Grpc.Services;
using MeteorFlow.Infrastructure;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Infrastructure.Repositories;
using MeteorFlow.Infrastructure.Web.Authorization.Policies;
using MeteorFlow.Web.Authorizations;
using MeteorFlow.Web.Configurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var appSettings = new AppConfig();
builder.Configuration.Bind(appSettings);
builder.Services.AddApplicationServices();
builder.Services.AddCommandHandlers(Assembly.GetExecutingAssembly());
builder.Services.AddQueryHandlers(Assembly.GetExecutingAssembly());
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCoreRepositories();
builder.Services.AddCoreUow();
builder.Services.AddCoreServices();
builder.Services.AddDateTimeProvider();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationPolicies(Assembly.GetExecutingAssembly(), AuthorizationPolicyNames.GetPolicyNames());

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000/index.html",
                    "http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
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

app.UseSwagger();
if (app.Environment.IsDevelopment()) {
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "gRPC V1");
    });
}

// Configure the HTTP request pipeline.
app.MapGrpcService<DefinitionMessageService>();
app.UseAuthorization();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();