﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlowerInventory.Migrations
{
    [DbContext(typeof(FlowerInventoryContext))]
    [Migration("20250404154158_SeedDataInContextUpdate")]
    partial class SeedDataInContextUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlowerInventory.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Roses"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tulips"
                        });
                });

            modelBuilder.Entity("FlowerInventory.Models.Flower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Flowers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Red Rose",
                            Price = 5.00m,
                            Type = "Rose"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "White Rose",
                            Price = 6.00m,
                            Type = "Rose"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "Yellow Tulip",
                            Price = 3.00m,
                            Type = "Tulip"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "Purple Tulip",
                            Price = 4.00m,
                            Type = "Tulip"
                        });
                });

            modelBuilder.Entity("FlowerInventory.Models.Flower", b =>
                {
                    b.HasOne("FlowerInventory.Models.Category", "Category")
                        .WithMany("Flowers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FlowerInventory.Models.Category", b =>
                {
                    b.Navigation("Flowers");
                });
#pragma warning restore 612, 618
        }
    }
}
