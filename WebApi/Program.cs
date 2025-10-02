using System.Security.Claims;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encyrption;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
            ClockSkew = TimeSpan.Zero
        };

        // EVENT HANDLER'LARI EKLEYÝN
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                Console.WriteLine("=== TOKEN ALINIYOR ===");
                var authHeader = context.Request.Headers["Authorization"].ToString();
                Console.WriteLine("Authorization Header: " + authHeader);
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("=== AUTHENTICATION BAÞARISIZ ===");
                Console.WriteLine("Hata: " + context.Exception?.Message);
                Console.WriteLine("Inner: " + context.Exception?.InnerException?.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("=== TOKEN GEÇERLÝ ===");
                var userId = context.Principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Console.WriteLine("User ID: " + userId);
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                Console.WriteLine("=== CHALLENGE TETÝKLENDÝ ===");
                Console.WriteLine("Error: " + context.Error);
                Console.WriteLine("ErrorDescription: " + context.ErrorDescription);
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

builder.Services.AddDbContext<RentalCarDbContext>(ServiceLifetime.Singleton);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new AutofacBusinessModule());
    });

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();