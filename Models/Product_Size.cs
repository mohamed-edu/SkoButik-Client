using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace SkoButik_Client.Models
{
    public class Product_Size
    {
        [Key]
        public int Product_SizeId { get; set; }
        public string Size { get; set; }
     
        public ICollection<Product>? Products { get; set; }
    }
}
