using Microsoft.AspNetCore.Identity;

namespace Ecom1.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string adminEmail = "admin@techzone.com";
            string adminPassword = "Admin123!";

            var user = await userManager.FindByEmailAsync(adminEmail);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, adminPassword);

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}