using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await db.Database.MigrateAsync();

            if (await roleManager.Roles.AnyAsync() || await userManager.Users.AnyAsync()) return;

            await roleManager.CreateAsync(new IdentityRole(AuthorizatinConstants.Roles.ADMINISTRATOR));

            var adminUser = new ApplicationUser()
            {
                Email = AuthorizatinConstants.DEFAULT_ADMIN_USER,
                UserName = AuthorizatinConstants.DEFAULT_ADMIN_USER,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(adminUser, AuthorizatinConstants.DEFAULT_PASSWORD);

            await userManager.AddToRoleAsync(adminUser, AuthorizatinConstants.Roles.ADMINISTRATOR);

            var demoUser = new ApplicationUser()
            {
                Email = AuthorizatinConstants.DEFAULT_DEMO_USER,
                UserName = AuthorizatinConstants.DEFAULT_DEMO_USER,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(demoUser, AuthorizatinConstants.DEFAULT_PASSWORD);
        }
    }
}
