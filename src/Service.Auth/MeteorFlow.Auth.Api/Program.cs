using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Meteor.Auth.Api.Configuration;
using MeteorFlow.Auth;
using MeteorFlow.Infrastructure.Web.Endpoints;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json")
    .AddEnvironmentVariables();

var config = new AuthConfig();
builder.Configuration.Bind(config);

builder.Services.AddAuthModule(config);
builder.Services.AddNativeAuthentication(builder.Configuration);
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "oidc";
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
        options.Events = new JwtBearerEvents
        {
            // Get the token from either the authorization header or authentication cookie
            OnMessageReceived = context =>
            {
                string? authCookie = context.Request.Cookies["access_token"];
                string? authHeader = context.Request.Headers[HeaderNames.Authorization];

                // Token will be taken from Authorization header or if header is not set from authentication cookie.
                if (!string.IsNullOrEmpty(authCookie))
                {
                    context.Token = authCookie;
                }
                return Task.CompletedTask;
            }
        };
    })
    .AddCookie("Cookies")
    .AddOAuth("GitHub", options =>
    {
        options.ClientId = config.Github.ClientId;
        options.ClientSecret = config.Github.ClientSecret;
        options.CallbackPath = new PathString("/api/auth/github-callback");

        options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
        options.TokenEndpoint = "https://github.com/login/oauth/access_token";
        options.UserInformationEndpoint = "https://api.github.com/user";

        options.SaveTokens = true;

        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
        options.ClaimActions.MapJsonKey(ClaimTypes.Name, "login");
        options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

        options.Events = new OAuthEvents
        {
            OnCreatingTicket = async context =>
            {
                var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                response.EnsureSuccessStatusCode();

                var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;

                context.RunClaimActions(user);
            }
        };
    });;

builder.Services.AddAuthorization();
builder.Services.ConfigRouting().AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins", b => b
        .WithOrigins(config.Cors.AllowedOrigins)
        .AllowAnyMethod()
        .AllowAnyHeader());
});

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
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\n\nExample: \"Bearer 12345abcdef\""
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

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(config.Cors.AllowAnyOrigin ? "AllowAnyOrigin" : "AllowedOrigins"); // allow credentials

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
