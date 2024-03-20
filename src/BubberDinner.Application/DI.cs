using BubberDinner.Application.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Application
{
    public static class DI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
