using CandyShop.Model.Entities;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrderList();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}