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

            //modelBuilder.Entity<Category>()).HasData(
            //          new Category()
            //          {
            //              Id = 1,
            //              Name = "Categoria1",
            //              SubCategories = new List<Category>() {
            //            new Category() {Id = 2, Name = "Cateporia1.1",},
            //            new Category() {Id = 3, Name = "Cateporia1.2", SubCategories = new List<Category>(){
            //                      new Category() {Id = 4, Name = "Cateporia1.2.1"}
            //            } }
            //          }
            //          },
            //          new Category() { Id = 5, Name = "Cateporia3" });
        }

        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
