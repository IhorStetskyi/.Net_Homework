using DapperLib.Models;
using System.Collections.Generic;


namespace DapperLib.DALInterfaces
{
    public interface IOrderController
    {
        public List<Order> GetAllOrders();
        public void InsertOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(int orderId);
        public List<Order> GetAllOrdersFiltrated(int month = -1, string status = "", int year = -1, int productId = -1);
        public void DeleteOrdersFiltrated(int month = -1, string status = "", int year = -1, int productId = -1);
        public void CreateStoredProcedures();
        public void UpdateOrCreateOrdersTable();

    }
}
