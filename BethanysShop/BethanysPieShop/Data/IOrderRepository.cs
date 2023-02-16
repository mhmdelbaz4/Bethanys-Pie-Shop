using BethanysPieShop.Models;

namespace BethanysPieShop.Data
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
    }
}
