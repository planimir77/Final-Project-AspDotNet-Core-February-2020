using CustomERP.Common;

namespace CustomERP.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    internal class FirstAdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (await dbContext.Users.AnyAsync())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var admin = await this.SeedUserAsync(userManager);

            await this.SeedSetUserRoleAsync(userManager, admin);
        }

        private static void ResultSucceeded(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }
        }

        private async Task SeedSetUserRoleAsync(UserManager<ApplicationUser> userManager, ApplicationUser admin)
        {
            var result = await userManager.AddToRoleAsync(admin, GlobalConstants.RoleName.Administrator);

            ResultSucceeded(result);
        }

        private async Task<ApplicationUser> SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = new ApplicationUser
            {
                UserName = "admin@erp.com",
                Email = "admin@erp.com",
                CreatorUserId = "FirstUser",
            };

            var result = await userManager.CreateAsync(admin, "123456");

            ResultSucceeded(result);

            return admin;
        }
    }
}
