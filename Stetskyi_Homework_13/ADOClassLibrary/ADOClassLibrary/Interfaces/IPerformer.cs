﻿using ADOClassLibrary.Models;
using System.Collections.Generic;


namespace ADOClassLibrary.Interfaces
{
    public interface IPerformer
    {
        public List<Product> GetAllProducts();
        public int InsertProduct(Product product);
        public int DeleteProduct(int productId);
        public int UpdateProduct(Product product);


        public List<Order> GetAllOrders(int month = -1, string status = "", int year = -1, int productId = -1);
        public void DeleteOrders(int month = -1, string status = "", int year = -1, int productId = -1);
        public List<Order> GetAllOrders();
        public int InsertOrder(Order order);
        public int DeleteOrder(int orderId);
        public int UpdateOrder(Order order);
        


        public void CreateStoredProcedures();
        public void DeleteStoredProcedures();
        public void UpdateDB();
    }
}
