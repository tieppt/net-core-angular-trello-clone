using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trollo.API.Data;
using Trollo.Identity.Identity;

namespace Trollo.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var serviceScope = host.Services.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            await dbContext.Database.MigrateAsync();

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<UserRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new UserRole("Admin");
                await roleManager.CreateAsync(adminRole);
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                var userRole = new UserRole("User");
                await roleManager.CreateAsync(userRole);
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}