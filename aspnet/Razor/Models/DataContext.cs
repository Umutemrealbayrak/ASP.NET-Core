using Microsoft.EntityFrameworkCore;
using Razor;

namespace razorpagesExample.Models;

public class DataContext:DbContext
{
    public DbSet<Employess> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-EH7GV89\SQLEXPRESS;Database=RazorDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}