using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoButik_Client.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public byte[] Picture { get; set; }

        [ForeignKey("Product_Brand")]
        public int FkProduct_BrandId { get; set; }
        public Product_Brand? Product_Brand { get; set; }

        [ForeignKey("Product_Inventory")]
        public int FkProduct_InventoryId { get; set; }
        public Product_Inventory? Product_Inventory { get; set; }

        [ForeignKey("Discount")]
        public int DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public ICollection<Order_Item>? Order_Items { get; set; }
        public ICollection<Cart_Item>? Cart_Items { get; set; }
        public ICollection<Product_Brand>? Product_Brandss { get; set; }

    }
}
