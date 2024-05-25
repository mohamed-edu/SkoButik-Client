using SkoButik_Client.Models;

namespace SkoButik_Client.Data.ViewModels
{
    public class AdminDashboardViewModel
    {
        public List<OrderStatsViewModel> OrderStats { get; set; }
        public ProductStatsViewModel MostSoldProduct { get; set; }
        public List<Order> Orders { get; set; }
        public List<Inventory> Inventories { get; set; }
    }
}
