using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using lab234.Models;

namespace lab234.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Iphone 11 Pro Max"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Pixel 4 XL"
                }
            );
            builder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName = "IphoneX",
                    ProductImage = "iphoneX.jpg",
                    Descriptions = "This is the Description!",
                    ProductQuantity = 1,
                    ProductPrice = 400,
                    CreateDate = DateTime.Now,
                    CategoryId = 1
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Pixel 4 XL",
                    ProductImage = "pixel.jpg",
                    Descriptions = "This is the Description!",
                    ProductQuantity = 1,
                    ProductPrice = 500,
                    CreateDate = DateTime.Now,
                    CategoryId = 1
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Linux iz da Bezt <3",
                    ProductImage = "linux.png",
                    Descriptions = "This is the Description!",
                    ProductQuantity = 1,
                    ProductPrice = 999,
                    CreateDate = DateTime.Now,
                    CategoryId = 1
                }
            );
        }
    }
}