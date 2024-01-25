using Microsoft.EntityFrameworkCore;
using ShoppingList.Data.Models;

namespace ShoppingList.Data
{
    public class ShoppingListDbContext : DbContext
    {

        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product() { Id = 1, Name = "Cheese" }, new Product() { Id=2, Name="Ham"});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductNote> ProductNotes { get; set; }
    }
}
