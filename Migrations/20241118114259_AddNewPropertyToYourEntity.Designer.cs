﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orders_Managment_System.Models;

#nullable disable

namespace Orders_Managment_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118114259_AddNewPropertyToYourEntity")]
    partial class AddNewPropertyToYourEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Orders_Managment_System.Models.Delivery", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("deliverydate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("shipingdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("deliveries");
                });

            modelBuilder.Entity("Orders_Managment_System.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total_Amount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Orders_Managment_System.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("payments");
                });

            modelBuilder.Entity("Orders_Managment_System.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Orders_Managment_System.Models.UserPremsion", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PremesionId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "PremesionId");

                    b.ToTable("userPremsions");
                });

            modelBuilder.Entity("Orders_Managment_System.Models.Delivery", b =>
                {
                    b.HasOne("Orders_Managment_System.Models.Order", "order")
                        .WithOne("delivery")
                        .HasForeignKey("Orders_Managment_System.Models.Delivery", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("Orders_Managment_System.Models.Payment", b =>
                {
                    b.HasOne("Orders_Managment_System.Models.Order", "order")
                        .WithOne("payment")
                        .HasForeignKey("Orders_Managment_System.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("Orders_Managment_System.Models.Order", b =>
                {
                    b.Navigation("delivery")
                        .IsRequired();

                    b.Navigation("payment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
