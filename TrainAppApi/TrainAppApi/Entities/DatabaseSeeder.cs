using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutAppApi.Entities
{
    public static class DatabaseSeeder
    {
        public static async Task Seed(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationContext>();
            context.Database.EnsureCreated();
            var userManager = services.GetRequiredService<UserManager<UserEntity>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await SeedTestUsers(roleManager, userManager);
        }

        private static async Task SeedTestUsers(RoleManager<IdentityRole> roleManager, UserManager<UserEntity> userManager)
        {
            var initialized = roleManager.Roles.Any() | userManager.Users.Any();
            if (!initialized)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                var user = new UserEntity()
                {
                    Email = "romanmail.by@gmail.com",
                    UserName = "romanmail.by@gmail.com",
                    FirstName = "Roma",
                    LastName = "Nosovich",
                    CreatedAt = DateTime.UtcNow
                };

                await userManager.CreateAsync(user, "Workout1!");
                await userManager.AddToRoleAsync(user, "Admin");
                await userManager.UpdateAsync(user);

            }
        }
    }
}
