using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Controllers;

namespace ProductsAPI.Models
{
    public class ProductContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product(){ProductId = 1,ProductName="IPhone14",price=60000,IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product(){ProductId = 2,ProductName="IPhone15",price=70000,IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product(){ProductId = 3,ProductName="IPhone16",price=80000,IsActive=false});
            modelBuilder.Entity<Product>().HasData(new Product(){ProductId = 4,ProductName="IPhone17",price=90000,IsActive=true});
            modelBuilder.Entity<Product>().HasData(new Product(){ProductId = 5,ProductName="IPhone18",price=100000,IsActive=true});
        }
        public DbSet<Product> Products { get; set; }

    }
    
}