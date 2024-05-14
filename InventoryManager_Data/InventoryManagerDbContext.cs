namespace InventoryManager_Data
{
    using InventoryManager_Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class InventoryManagerDbContext : DbContext
    {
        public InventoryManagerDbContext(DbContextOptions<InventoryManagerDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<ProductManager> ProductManagers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}