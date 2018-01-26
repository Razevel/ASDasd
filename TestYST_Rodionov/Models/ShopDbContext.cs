using System.Data.Entity;
using TestYST_Rodionov.Models.Entities;

namespace TestYST_Rodionov.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("FullDBConStr") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<StockBalance> StockBalances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasMany(s => s.StockBalance)
                .WithRequired(sb => sb.Stock);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.StockBalance)
                .WithRequired(sb => sb.Product);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithRequired(o => o.Product);

            modelBuilder.Entity<Cart>()
                .HasMany(shb => shb.Orders)
                .WithRequired(o => o.OwnerBag);
            

        }
    }
}
