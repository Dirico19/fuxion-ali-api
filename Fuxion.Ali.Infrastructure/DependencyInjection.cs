using Fuxion.Ali.Application.Security;
using Fuxion.Ali.Domain.Interfaces;
using Fuxion.Ali.Domain.Interfaces.Repositories;
using Fuxion.Ali.Infrastructure.Persistence;
using Fuxion.Ali.Infrastructure.Persistence.Repositories;
using Fuxion.Ali.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fuxion.Ali.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddSecurity(configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            services.AddSingleton<IJwtProvider, JwtProvider>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
