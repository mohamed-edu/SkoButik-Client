using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkoButik_Client.Models
{
    public class Payment_Detail
    {
        [Key]
        public int Payment_DetailId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public bool Registered { get; set; } = false;
        public string Provider { get; set; }
        public string Status { get; set; }

        public ICollection<Order_Detail>? Order_Detail { get; set; }
    }
}
