using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoButik_Client.Models
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        public string DiscountName { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount_Percent { get; set; }
        public bool Active { get; set; } = false;

        public DateTime Discount_StartDate { get; set; }
        public DateTime Discount_EndDate { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
