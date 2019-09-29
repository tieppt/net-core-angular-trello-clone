using Microsoft.Extensions.DependencyInjection;
using Trollo.Common.Filters;
using Trollo.Common.Services;
using Trollo.Common.Services.Contracts;
using Trollo.Identity.Services;
using Trollo.Identity.Services.Contracts;

namespace TrolloAPI.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IServiceInvoker, ServiceInvoker>();
            services.AddSingleton<GlobalExceptionFilter>();
            services.AddSingleton<IExceptionResultBuilder, ExceptionResultBuilder>();

            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}