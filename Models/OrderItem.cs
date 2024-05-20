﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkoButik_Client.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int Amount { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("Product")]
        public int FkProductId { get; set; }
        public Product? Products { get; set; }


        [ForeignKey("Order")]
        public int FkOrderId { get; set; }
        public Order? Orders { get; set; }
    }
}
