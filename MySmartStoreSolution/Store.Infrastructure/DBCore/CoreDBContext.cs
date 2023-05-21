using Microsoft.EntityFrameworkCore;
using Store.Domain.Entity;

namespace Store.Infrastructure.DBCore
{
    public class CoreDBContext : DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options) : base(options)
        {
            base.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Phone).IsUnique();
            
            modelBuilder.Entity<Customer>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<OrderItem>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<OrderItem>().Property(u => u.UnitPrice).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<ProductCategory>().HasIndex(u => u.Id).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
