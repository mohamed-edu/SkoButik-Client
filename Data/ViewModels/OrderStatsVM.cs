using System;

namespace SkoButik_Client.Models
{
    public class OrderStatsViewModel
    {
        public DateTime OrderDate { get; set; }
        public int OrderCount { get; set; }
        public decimal TotalSales { get; set; }
    }
}