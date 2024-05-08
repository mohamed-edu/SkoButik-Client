using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class Shopping_Session
    {
        [Key]
        public int Shopping_SessionId { get; set; }

        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer? Customer { get; set; }

        public ICollection<Cart_Item>? Cart_Items { get; set; }
    }
}
