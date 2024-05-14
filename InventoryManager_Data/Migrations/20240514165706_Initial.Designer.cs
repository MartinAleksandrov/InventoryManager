﻿// <auto-generated />
using System;
using InventoryManager_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryManager_Data.Migrations
{
    [DbContext(typeof(InventoryManagerDbContext))]
    [Migration("20240514165706_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InventoryManager_Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasMaxLength(9999)
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProductManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProductManagerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("InventoryManager_Data.Models.ProductManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ProductManagers");
                });

            modelBuilder.Entity("InventoryManager_Data.Models.Product", b =>
                {
                    b.HasOne("InventoryManager_Data.Models.ProductManager", null)
                        .WithMany("Products")
                        .HasForeignKey("ProductManagerId");
                });

            modelBuilder.Entity("InventoryManager_Data.Models.ProductManager", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
