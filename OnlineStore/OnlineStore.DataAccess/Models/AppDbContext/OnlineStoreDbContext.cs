using Microsoft.EntityFrameworkCore;
using OnlineStore.DataAccess.Models.Entities;

namespace OnlineStore.DataAccess.Models.AppDbContext
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>()
            .HasKey(o => new { o.UserId, o.ProductId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
