using TestingApp.Data.EfContext;
using TestingApp.Data.Entities.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System;

namespace TestingApp.Data.SeedData
{
    public class Seed
    {
        public static async Task SeedData(IServiceProvider services, IHostEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EfDbContext>();
                await PreConfigured.SeedRoles(managerRole);
                await PreConfigured.SeedUsers(manager);
                PreConfigured.SeedTests(context);
            }
        }
    }
}
