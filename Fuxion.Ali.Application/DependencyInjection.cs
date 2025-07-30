using Fuxion.Ali.Application.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Fuxion.Ali.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
