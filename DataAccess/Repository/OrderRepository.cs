using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrdersByDate(DateTime startDate, DateTime endDate) => OrderDAO.Instance.GetOrdersByDate(startDate, endDate);

        public IEnumerable<Order> GetOrdersByUser(string email) => OrderDAO.Instance.GetOrdersByUser(email);
        
        public IEnumerable<Order> GetAllOrders() => OrderDAO.Instance.GetAllOrders();
        
        public Order getOrderById(int id) => OrderDAO.Instance.getOrderById(id);

        public void AddOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);

        public void DeleteOrder(Order order) => OrderDAO.Instance.DeleteOrder(order);

    }
}
