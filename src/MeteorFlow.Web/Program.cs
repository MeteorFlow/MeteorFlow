using MeteorFlow.Core.Extensions;
using MeteorFlow.Infrastructure.Extensions;
using MeteorFlow.Infrastructure.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add configuration from app settings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

// Add services to the container.
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCoreServices();

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
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true) // allow any origin
                                   //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
    .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();