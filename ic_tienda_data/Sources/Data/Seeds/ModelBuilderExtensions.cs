using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ic_tienda_data.Sources.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ic_tienda_data.Sources.Data.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seeds(this ModelBuilder modelBuilder)
        {
            // Semillas para Productos
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "iPhone 13", Price = 799.99m, Stock = 50, Description = "Cámara 12MP." },
                new Product { Id = 2, CategoryId = 1, Name = "Samsung Galaxy S21", Price = 699.99m, Stock = 60, Description = "Pantalla 120Hz." },
                new Product { Id = 3, CategoryId = 1, Name = "OnePlus 9", Price = 729.99m, Stock = 45, Description = "Cámara 48MP." },
                new Product { Id = 4, CategoryId = 1, Name = "Google Pixel 6", Price = 599.99m, Stock = 30, Description = "Cámara avanzada." },
                new Product { Id = 5, CategoryId = 2, Name = "Dell XPS 13", Price = 999.99m, Stock = 40, Description = "i7 ultradelgada." },
                new Product { Id = 6, CategoryId = 2, Name = "MacBook Air M1", Price = 999.00m, Stock = 35, Description = "Batería de 15 horas." },
                new Product { Id = 7, CategoryId = 2, Name = "HP Spectre x360", Price = 1299.99m, Stock = 20, Description = "Pantalla 4K." },
                new Product { Id = 8, CategoryId = 2, Name = "Lenovo ThinkPad X1", Price = 1499.99m, Stock = 15, Description = "Teclado retroiluminado." },
                new Product { Id = 9, CategoryId = 3, Name = "Bose QC35", Price = 299.99m, Stock = 80, Description = "Cancelación de ruido." },
                new Product { Id = 10, CategoryId = 3, Name = "Sony WH-1000XM4", Price = 349.99m, Stock = 70, Description = "Cancelación activa." },
                new Product { Id = 11, CategoryId = 3, Name = "JBL 650BT", Price = 129.99m, Stock = 100, Description = "Sonido claro." },
                new Product { Id = 12, CategoryId = 3, Name = "Sennheiser Momentum", Price = 299.99m, Stock = 60, Description = "Audio de alta calidad." },
                new Product { Id = 13, CategoryId = 4, Name = "iPad Pro 11", Price = 799.99m, Stock = 40, Description = "Pantalla Retina." },
                new Product { Id = 14, CategoryId = 4, Name = "Samsung Galaxy Tab S7", Price = 649.99m, Stock = 50, Description = "Pantalla 120Hz." },
                new Product { Id = 15, CategoryId = 4, Name = "Microsoft Surface Pro 7", Price = 899.99m, Stock = 30, Description = "Con pantalla táctil." },
                new Product { Id = 16, CategoryId = 5, Name = "Garmin Venu 2", Price = 249.99m, Stock = 100, Description = "GPS integrado." },
                new Product { Id = 17, CategoryId = 5, Name = "Apple Watch Series 7", Price = 399.99m, Stock = 50, Description = "Pantalla siempre encendida." },
                new Product { Id = 18, CategoryId = 5, Name = "Fitbit Sense", Price = 299.99m, Stock = 60, Description = "Monitoreo de salud." },
                new Product { Id = 19, CategoryId = 5, Name = "Amazfit GTR 3", Price = 179.99m, Stock = 80, Description = "Pantalla AMOLED." },
                new Product { Id = 20, CategoryId = 5, Name = "GoPro Hero 9", Price = 399.99m, Stock = 60, Description = "Cámara de acción." }
            );


            // Semillas para Categorias
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Smartphones", Description = "Teléfonos avanzados." },
                new Category { Id = 2, Name = "Laptops", Description = "Computadoras portátiles." },
                new Category { Id = 3, Name = "Auriculares", Description = "Dispositivos de audio." },
                new Category { Id = 4, Name = "Tablets", Description = "Pantallas táctiles." },
                new Category { Id = 5, Name = "Relojes inteligentes", Description = "Relojes con funciones smart." }
            );


        }
    }
}