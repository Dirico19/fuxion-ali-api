using Fuxion.Ali.Application.Auth;
using Fuxion.Ali.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Fuxion.Ali.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
