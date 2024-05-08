using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class Order_Detail
    {
        [Key]
        public int Order_DetailId { get; set; }

        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Payment_Details")]
        public int FkPayment_DetailsId { get; set; }
        public Payment_Detail? Payment_Details { get; set; }

        public ICollection<Order_Item>? Order_Items { get; set; }
    }
}
