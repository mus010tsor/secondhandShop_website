using Microsoft.AspNetCore.Identity;

namespace WebProje.Data
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Yönetici", "Kullanıcı" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // İlk kayıt olan kullanıcıyı Yönetici yap (geliştirme için)
            var firstUser = userManager.Users.OrderBy(u => u.Id).FirstOrDefault();
            if (firstUser != null && !await userManager.IsInRoleAsync(firstUser, "Yönetici"))
            {
                await userManager.AddToRoleAsync(firstUser, "Yönetici");
            }
        }
    }
}
