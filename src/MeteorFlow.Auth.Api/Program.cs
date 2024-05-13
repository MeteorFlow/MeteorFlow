using System.Reflection;
using MeteorFlow.Auth;
using MeteorFlow.Fx;
using MeteorFlow.Infrastructure.Configurations;
using MeteorFlow.Infrastructure.DateTimes;
using MeteorFlow.Infrastructure.Web.Endpoints;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config = new AppConfig();
builder.Configuration.Bind(config);


// Add services to the container.
builder.Services.AddCommandHandlers(Assembly.GetExecutingAssembly());
builder.Services.AddQueryHandlers(Assembly.GetExecutingAssembly());
builder.Services.AddDateTimeProvider();

builder.Services.AddNativeAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.ConfigRouting().AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins", b => b
        .WithOrigins(config.Cors.AllowedOrigins)
        .AllowAnyMethod()
        .AllowAnyHeader());
});

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

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
