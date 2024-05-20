using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 10)]
        [DisplayName("Size")]
        public string SizeName {  get; set; }

        public ICollection<Product>? Products { get; set;}
        public ICollection<ProductSizeInventory> ProductSizeInventories { get; set; }
    }
}
