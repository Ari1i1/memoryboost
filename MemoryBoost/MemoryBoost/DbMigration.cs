using System;
using System.Threading.Tasks;
using MemoryBoost.Data;
using MemoryBoost.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MemoryBoost
{
    public static class DbMigration
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
                DbMigration.ConfigureIdentity(scope).GetAwaiter().GetResult();
                DbMigration.CreateGameLevels(scope).GetAwaiter().GetResult();
            }

            return webHost;
        }

        private static async Task ConfigureIdentity(IServiceScope scope)
        {
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            var adminsRole = await roleManager.FindByNameAsync(ApplicationRoles.Administrators);

            if (adminsRole == null)
            {
                var adminsRoleResult = await roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Administrators));
                if (!adminsRoleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unable to create {ApplicationRoles.Administrators} role.");
                }

                adminsRole = await roleManager.FindByNameAsync(ApplicationRoles.Administrators);
            }

            var adminUser = await userManager.FindByNameAsync("admin@localhost.local");
            if (adminUser == null)
            {
                var adminUserResult = await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@localhost.local",
                    Email = "admin@localhost.local"
                }, "AdminPass123!");
                if (!adminUserResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unable to create admin@localhost.local user");
                }

                adminUser = await userManager.FindByNameAsync("admin@localhost.local");
            }

            if (!await userManager.IsInRoleAsync(adminUser, adminsRole.Name))
            {
                await userManager.AddToRoleAsync(adminUser, adminsRole.Name);
            }
        }
        private static async Task CreateGameLevels(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            var gameLevels = context.GameLevels;

            var firstLevel = await gameLevels.FindAsync(10);
            if (firstLevel == null)
            {
                var firstLevelResult = new GameLevel
                {
                    Name = "The Easy One",
                    CardsNumber = 12,
                    SecForMemorizing = 12
                };
                context.Add(firstLevelResult);
                await context.SaveChangesAsync();
            }
            var secondLevel = await gameLevels.FindAsync(11);
            if (secondLevel == null)
            {
                var secondLevelResult = new GameLevel
                {
                    Name = "Try Yourself",
                    CardsNumber = 18,
                    SecForMemorizing = 15
                };
                context.Add(secondLevelResult);
                await context.SaveChangesAsync();
            }
            var thirdLevel = await gameLevels.FindAsync(12);
            if (thirdLevel == null)
            {
                var thirdLevelResult = new GameLevel
                {
                    Name = "Hardcore",
                    CardsNumber = 24,
                    SecForMemorizing = 20
                };
                context.Add(thirdLevelResult);
                await context.SaveChangesAsync();
            }
        }
    }
}

