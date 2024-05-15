using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoButik_Client.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
    }
}
