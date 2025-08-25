using Fuxion.Ali.Application;
using Fuxion.Ali.Infrastructure;
using Fuxion.Ali.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>() ?? throw new InvalidOperationException("JWT settings are not configured properly.");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

// Add cors policy
var pwaUrl = builder.Configuration.GetValue<string>("PwaUrl") ?? throw new InvalidOperationException("PWA URL is not configured.");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPWAOrigin",
        builder => builder.WithOrigins(pwaUrl)
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Use cors policy
app.UseCors("AllowPWAOrigin");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//// Generate a password hash for testing purposes
//Console.Write("Ingresa una contraseña: ");
//var password = Console.ReadLine();

//var hasher = new PasswordHasher();
//var hash = hasher.Hash(password!);

//Console.WriteLine($"\nHash generado:");
//Console.WriteLine(hash);