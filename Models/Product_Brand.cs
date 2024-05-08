using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class Product_Brand
    {
        [Key]
        public int Product_BrandId { get; set; }
        public string Brand { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
