using SkoButik_Client.Models;

namespace SkoButik_Client.Data.Services
{
    public interface ITarget
    {
        decimal CalculateTotalSales(List<OrderItem> orderItems);
    }
}
