using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrolloAPI.Data;

namespace TrolloAPI.Extensions
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
                .AddSqlServer(connectionString, null, "SqlServer");
        }
    }
}
