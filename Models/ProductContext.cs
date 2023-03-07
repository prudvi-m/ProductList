using Microsoft.EntityFrameworkCore;

namespace ProductList.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product {
                    ProductId = 1,
                    Name = "Us Polo T-Shirt",
                    Code = 2000,
                    CategoryId = 1,
                    WarehouseId = 1
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Clothing" },
                new Category { CategoryId = 2, Name = "Food" },
                new Category { CategoryId = 3, Name = "Grocery" },
                new Category { CategoryId = 4, Name = "Electronics" },
                new Category { CategoryId = 5, Name = "Home" },
                new Category { CategoryId = 6, Name = "Garden" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Warehouse { WarehouseId = 1, Name = "Chicago" },
                new Warehouse { WarehouseId = 2, Name = "New York" },
                new Warehouse { WarehouseId = 3, Name = "San Francisco" },
                new Warehouse { WarehouseId = 4, Name = "Miami" }
            );
        }
    }
}