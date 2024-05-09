﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkoButik_Client.Data;

#nullable disable

namespace SkoButik_Client.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240509095246_ApplicationUserExtedDboNetUse")]
    partial class ApplicationUserExtedDboNetUse
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SkoButik_Client.Models.Cart_Item", b =>
                {
                    b.Property<int>("Cart_ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cart_ItemId"));

                    b.Property<DateTime>("Cart_Item_EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Cart_Item_Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Cart_Item_StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Shopping_SessionId")
                        .HasColumnType("int");

                    b.HasKey("Cart_ItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("Shopping_SessionId");

                    b.ToTable("Cart_Items");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Discount_EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount_Percent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Discount_StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Order_Detail", b =>
                {
                    b.Property<int>("Order_DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_DetailId"));

                    b.Property<int>("FkCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("FkPayment_DetailsId")
                        .HasColumnType("int");

                    b.HasKey("Order_DetailId");

                    b.HasIndex("FkCustomerId");

                    b.HasIndex("FkPayment_DetailsId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Order_Item", b =>
                {
                    b.Property<int>("Order_ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_ItemId"));

                    b.Property<int>("FkOrder_DetailId")
                        .HasColumnType("int");

                    b.Property<int>("FkProductId")
                        .HasColumnType("int");

                    b.HasKey("Order_ItemId");

                    b.HasIndex("FkOrder_DetailId");

                    b.HasIndex("FkProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Payment_Detail", b =>
                {
                    b.Property<int>("Payment_DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Payment_DetailId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Registered")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Payment_DetailId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int>("FkProduct_BrandId")
                        .HasColumnType("int");

                    b.Property<int>("FkProduct_InventoryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("FkProduct_BrandId");

                    b.HasIndex("FkProduct_InventoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product_Brand", b =>
                {
                    b.Property<int>("Product_BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_BrandId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Product_BrandId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBrands");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product_Inventory", b =>
                {
                    b.Property<int>("Product_InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_InventoryId"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Product_InventoryId");

                    b.ToTable("ProductInventories");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Shopping_Session", b =>
                {
                    b.Property<int>("Shopping_SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Shopping_SessionId"));

                    b.Property<int>("FkCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Shopping_SessionId");

                    b.HasIndex("FkCustomerId");

                    b.ToTable("ShoppingSessions");
                });

            modelBuilder.Entity("SkoButik_Client.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkoButik_Client.Models.Cart_Item", b =>
                {
                    b.HasOne("SkoButik_Client.Models.Product", "Product")
                        .WithMany("Cart_Items")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkoButik_Client.Models.Shopping_Session", "Shopping_Session")
                        .WithMany("Cart_Items")
                        .HasForeignKey("Shopping_SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Shopping_Session");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Order_Detail", b =>
                {
                    b.HasOne("SkoButik_Client.Models.Customer", "Customer")
                        .WithMany("Order_Details")
                        .HasForeignKey("FkCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkoButik_Client.Models.Payment_Detail", "Payment_Details")
                        .WithMany("Order_Detail")
                        .HasForeignKey("FkPayment_DetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Payment_Details");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Order_Item", b =>
                {
                    b.HasOne("SkoButik_Client.Models.Order_Detail", "Order_Detail")
                        .WithMany("Order_Items")
                        .HasForeignKey("FkOrder_DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkoButik_Client.Models.Product", "Product")
                        .WithMany("Order_Items")
                        .HasForeignKey("FkProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order_Detail");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product", b =>
                {
                    b.HasOne("SkoButik_Client.Models.Discount", "Discount")
                        .WithMany("Products")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkoButik_Client.Models.Product_Brand", "Product_Brand")
                        .WithMany("Products")
                        .HasForeignKey("FkProduct_BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkoButik_Client.Models.Product_Inventory", "Product_Inventory")
                        .WithMany("Products")
                        .HasForeignKey("FkProduct_InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Product_Brand");

                    b.Navigation("Product_Inventory");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product_Brand", b =>
                {
                    b.HasOne("SkoButik_Client.Models.Product", null)
                        .WithMany("Product_Brandss")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Shopping_Session", b =>
                {
                    b.HasOne("SkoButik_Client.Models.Customer", "Customer")
                        .WithMany("Shopping_Sessions")
                        .HasForeignKey("FkCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Customer", b =>
                {
                    b.Navigation("Order_Details");

                    b.Navigation("Shopping_Sessions");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Discount", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Order_Detail", b =>
                {
                    b.Navigation("Order_Items");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Payment_Detail", b =>
                {
                    b.Navigation("Order_Detail");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product", b =>
                {
                    b.Navigation("Cart_Items");

                    b.Navigation("Order_Items");

                    b.Navigation("Product_Brandss");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product_Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Product_Inventory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SkoButik_Client.Models.Shopping_Session", b =>
                {
                    b.Navigation("Cart_Items");
                });
#pragma warning restore 612, 618
        }
    }
}
