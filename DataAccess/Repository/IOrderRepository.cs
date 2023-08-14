using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        // perform the same functions in IMemberRepository
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate);
        IEnumerable<Order> GetOrdersByUser(string email);
        Order getOrderById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
