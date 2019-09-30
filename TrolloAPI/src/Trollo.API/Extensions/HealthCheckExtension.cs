using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TrolloAPI.Extensions
{
    public static class HealthCheckExtension
    {
        public static void AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecksUI()
                .AddHealthChecks()
                .AddUrlGroup(
                    options =>
                    {
                        // TODO: Get BaseURL programmatically or add to appsettings
                        options.AddUri(new Uri("https://localhost:5001/api/v1/docs"),
                            uriOptions => { uriOptions.UseGet(); });
                    }, "Swagger", HealthStatus.Unhealthy)
                .AddSqlServer(configuration.GetConnectionString("Default"), null, "SqlServer");
        }
    }
}