﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab234.Data;

namespace lab234.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200511001712_InitData")]
    partial class InitData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab234.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Iphone 11 Pro Max"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Pixel 4 XL"
                        });
                });

            modelBuilder.Entity("lab234.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("lab234.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("lab234.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            CreateDate = new DateTime(2020, 5, 11, 7, 17, 11, 649, DateTimeKind.Local).AddTicks(6653),
                            Descriptions = "This is the Description!",
                            ProductImage = "iphoneX.jpg",
                            ProductName = "IphoneX",
                            ProductPrice = 400.0,
                            ProductQuantity = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            CreateDate = new DateTime(2020, 5, 11, 7, 17, 11, 653, DateTimeKind.Local).AddTicks(4041),
                            Descriptions = "This is the Description!",
                            ProductImage = "pixel.jpg",
                            ProductName = "Pixel 4 XL",
                            ProductPrice = 500.0,
                            ProductQuantity = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            CreateDate = new DateTime(2020, 5, 11, 7, 17, 11, 653, DateTimeKind.Local).AddTicks(4080),
                            Descriptions = "This is the Description!",
                            ProductImage = "linux.png",
                            ProductName = "Linux iz da Bezt <3",
                            ProductPrice = 999.0,
                            ProductQuantity = 1
                        });
                });

            modelBuilder.Entity("lab234.Models.OrderDetail", b =>
                {
                    b.HasOne("lab234.Models.Order", "Order")
                        .WithMany("OrderDetils")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab234.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lab234.Models.Product", b =>
                {
                    b.HasOne("lab234.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
