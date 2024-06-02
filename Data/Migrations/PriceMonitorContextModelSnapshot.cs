﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PriceMonitor.Data;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(PriceMonitorContext))]
    partial class PriceMonitorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PriceMonitor.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceMonitor.Domain.ProductTag", b =>
                {
                    b.Property<int>("ProductTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTagId"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ProductTagId");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("PriceMonitor.Domain.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            Name = "Selver"
                        },
                        new
                        {
                            StoreId = 2,
                            Name = "Rimi"
                        });
                });

            modelBuilder.Entity("PriceMonitor.Domain.StoreProduct", b =>
                {
                    b.Property<int>("StoreProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreProductId"));

                    b.Property<string>("ApiString")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("StoreProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreProducts");
                });

            modelBuilder.Entity("PriceMonitor.Domain.StoreProductPrice", b =>
                {
                    b.Property<int>("StoreProductPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreProductPriceId"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeUTC")
                        .HasPrecision(3)
                        .HasColumnType("datetime2(3)");

                    b.Property<bool>("HasDiscount")
                        .HasColumnType("bit");

                    b.Property<int>("StoreProductId")
                        .HasColumnType("int");

                    b.HasKey("StoreProductPriceId");

                    b.HasIndex("StoreProductId");

                    b.ToTable("StoreProductPrices");
                });

            modelBuilder.Entity("ProductProductTag", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TagsProductTagId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "TagsProductTagId");

                    b.HasIndex("TagsProductTagId");

                    b.ToTable("ProductProductTag");
                });

            modelBuilder.Entity("PriceMonitor.Domain.StoreProduct", b =>
                {
                    b.HasOne("PriceMonitor.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PriceMonitor.Domain.Store", "Store")
                        .WithMany("StoreProducts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PriceMonitor.Domain.StoreProductPrice", b =>
                {
                    b.HasOne("PriceMonitor.Domain.StoreProduct", "StoreProduct")
                        .WithMany()
                        .HasForeignKey("StoreProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreProduct");
                });

            modelBuilder.Entity("ProductProductTag", b =>
                {
                    b.HasOne("PriceMonitor.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PriceMonitor.Domain.ProductTag", null)
                        .WithMany()
                        .HasForeignKey("TagsProductTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PriceMonitor.Domain.Store", b =>
                {
                    b.Navigation("StoreProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
