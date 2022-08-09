using ADOClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOClassLibrary.Interfaces
{
    public interface IOrderPerformer
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand CMD { get; set; }
        public SqlDataAdapter SQLDataAdapter { get; set; }
        public DataSet DataSetValue { get; set; }
        public List<Order> GetAllOrders(int month = -1, string status = "", int year = -1, int productId = -1);
        public void DeleteOrders(int month = -1, string status = "", int year = -1, int productId = -1);
        public List<Order> GetAllOrders();
        public int InsertOrder(Order order);
        public int DeleteOrder(int orderId);
        public int UpdateOrder(Order order);
        public void CreateStoredProcedures();
        public void DeleteStoredProcedures();
        public void UpdateOrCreateOrdersTable();
        public void InitializeOrdersDB();
    }
}
