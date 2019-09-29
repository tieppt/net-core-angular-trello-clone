using Microsoft.Extensions.DependencyInjection;
using TrolloAPI.Services;
using TrolloAPI.Services.Contracts;

namespace TrolloAPI.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}