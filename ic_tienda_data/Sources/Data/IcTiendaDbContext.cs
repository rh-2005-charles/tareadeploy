using ic_tienda_data.Sources.Data.Models;
using ic_tienda_data.Sources.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.Sources.Data
{
    public class IcTiendaDbContext : DbContext
    {
        public IcTiendaDbContext(DbContextOptions<IcTiendaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacion de 1 a muchos de Product y Category
            modelBuilder.Entity<Category>()
              .HasMany<Product>()
              .WithOne()
              .HasForeignKey(p => p.CategoryId)
              .IsRequired();

            // Relación muchos a muchos entre Pedido y Producto, usando la tabla intermedia OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => op.Id);

            modelBuilder.Entity<Product>()
                .HasMany<OrderProduct>()
                .WithOne()
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany<OrderProduct>()
                .WithOne()
                .HasForeignKey(op => op.OrderId);


            // Seeders
            modelBuilder.Seeds();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}