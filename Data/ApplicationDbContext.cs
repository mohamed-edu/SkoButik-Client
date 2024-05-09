using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkoButik_Client.Models;

namespace SkoButik_Client.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Inventory> ProductInventories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order_Item> OrderItems { get; set; }
        public DbSet<Order_Detail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shopping_Session> ShoppingSessions { get; set; }
        public DbSet<Payment_Detail> PaymentDetails { get; set; }
        public DbSet<Product_Brand> ProductBrands { get; set; }
        public DbSet<Cart_Item> Cart_Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order_Item>()
                .HasOne(oi => oi.Order_Detail)
                .WithMany(od => od.Order_Items)
                .HasForeignKey(oi => oi.FkOrder_DetailId);

            modelBuilder.Entity<Order_Detail>()
                .HasOne(od => od.Customer)
                .WithMany(c => c.Order_Details)
                .HasForeignKey(od => od.FkCustomerId);

            modelBuilder.Entity<Order_Detail>()
                .HasOne(od => od.Payment_Details)
                .WithMany(pd => pd.Order_Detail)
                .HasForeignKey(od => od.FkPayment_DetailsId);

            modelBuilder.Entity<Shopping_Session>()
                .HasOne(ss => ss.Customer)
                .WithMany(c => c.Shopping_Sessions)
                .HasForeignKey(ss => ss.FkCustomerId);

            modelBuilder.Entity<Cart_Item>()
                .HasOne(ci => ci.Shopping_Session)
                .WithMany(ss => ss.Cart_Items)
                .HasForeignKey(ci => ci.Shopping_SessionId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Product_Brand)
                .WithMany(pb => pb.Products)
                .HasForeignKey(p => p.FkProduct_BrandId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Product_Inventory)
                .WithMany(pi => pi.Products)
                .HasForeignKey(p => p.FkProduct_InventoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Discount)
                .WithMany(d => d.Products)
                .HasForeignKey(p => p.DiscountId);

            modelBuilder.Entity<Cart_Item>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.Cart_Items)
                .HasForeignKey(ci => ci.ProductId);     

            modelBuilder.Entity<Order_Item>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.Order_Items)
                .HasForeignKey(oi => oi.FkProductId);

        }
    }
}
