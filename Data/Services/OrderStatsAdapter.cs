﻿using SkoButik_Client.Models;

namespace SkoButik_Client.Data.Services
{
    public class OrderStatsAdapter : ITarget
    {
        private readonly ApplicationDbContext _context;
        public OrderStatsAdapter(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal CalculateTotalSales(List<OrderItem> orderItems)
        {
            return orderItems.Sum(oi => oi.Amount * oi.Products.AdjustedPrice);
        }
    }
}
