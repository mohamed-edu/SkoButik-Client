﻿namespace SkoButik_Client.Models
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }
        public ApplicationUser OrderedBy { get; set; }
        public decimal TotalPrice { get; set; }
    }
}