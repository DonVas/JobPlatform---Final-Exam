namespace JobPlatform.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using JobPlatform.Common;
    using JobPlatform.Data.Common.Models;
    using JobPlatform.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await this.SeedUserAsync(userManager, GlobalConstants.Administrator);
        }

        public async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string roleName)
        {
            var user = await userManager.FindByNameAsync("bulaf88@abv.bg");

            if (user == null)
            {
                var result = await userManager.CreateAsync(
                    new ApplicationUser()
                {
                    UserName = "bulaf88@abv.bg",
                    Email = "bulaf88@abv.bg",
                },
                    "123456");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }

                user = await userManager.FindByNameAsync("bulaf88@abv.bg");
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
