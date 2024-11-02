using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Models
{
    public class IdentityContext:IdentityDbContext<AppUser,AppRole, int>
    {
        public IdentityContext(DbContextOptions<IdentityContext>options):base(options)
        {
            
        }
    }
}