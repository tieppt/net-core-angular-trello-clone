using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Trollo.API.Data;

namespace Trollo.API.Extensions
{
    public static class AppExtension
    {
        public static void ConfigureAppWithHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddHealthChecksUI()
                .AddHealthChecks()
                .AddUrlGroup(
                    options =>
                    {
                        // TODO: Get BaseURL programmatically or add to appsettings
                        options.AddUri(new Uri("https://localhost:5001/api/v1/docs"),
                            uriOptions => { uriOptions.UseGet(); });
                    }, "Swagger", HealthStatus.Unhealthy)
                .AddSqlServer(connectionString, null, "SqlServer");
        }
    }
}