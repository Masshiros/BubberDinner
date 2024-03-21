using System.Reflection;
using BubberDinner.Application.Common.Interfaces.Auth;
using BubberDinner.Application.Common.Interfaces.Services;
using BubberDinner.Application.Common.Persistent;
using BubberDinner.Infrastructure.Authentication;
using BubberDinner.Infrastructure.Persistent;
using BubberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BubberDinner.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtGenerator, JwtGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}
