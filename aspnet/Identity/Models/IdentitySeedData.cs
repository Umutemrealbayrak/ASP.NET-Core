using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class IdentitySeedData
    {
        private const string adminuser = "admin";
        private static readonly string adminpassword = "Admin#1234";  // İsteğe bağlı: Environment değişkeni ile de alabilirsiniz.

        public static async Task IdentityTestUser(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IdentityContext>();

                // Veritabanı migrationlarını uygulayın
                if (!context.Database.GetAppliedMigrations().Any())
                {
                    context.Database.Migrate();
                }

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                // Admin kullanıcısını kontrol edin
                var user = await userManager.FindByNameAsync(adminuser);
                if (user == null)
                {
                    // Yeni kullanıcı oluşturulması
                    user = new AppUser
                    {
                        FullName="UMUT ALBAYRAK",
                        UserName = adminuser,
                        Email = "albayrakumut727@gmail.com",
                        PhoneNumber = "123456789"
                    };

                    await userManager.CreateAsync(user, adminpassword);
                    
                }
            }
        }
    }
}
