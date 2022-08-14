using System;
using DapperLib;
using DapperLib.DALInterfaces;
using DapperLib.DALInterfaceImplementation;
using DapperLib.Models;
using System.Collections.Generic;
using DapperLib.InjectionFolder;
using Microsoft.Extensions.DependencyInjection;

namespace Justtest
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider container = Startup.ConfigureService();
            IOrderController orderController = container.GetRequiredService<IOrderController>();
            IProductController productController = container.GetRequiredService<IProductController>();

            productController.CreateStoredProcedures();
            orderController.CreateStoredProcedures();
            productController.UpdateOrCreateProductsTable();
            orderController.UpdateOrCreateOrdersTable();

            orderController.DeleteOrdersFiltrated(productId: 4);

            //List<Order> orders = orderController.GetAllOrders();
            //foreach (Order ord in orders)
            //{
            //    Console.WriteLine(ord.Status);
            //}

            //foreach (Order item in mockOrders())
            //{
            //    orderController.InsertOrder(item);
            //}
            // orderController.DeleteOrder(92);
            //List<Order> orders = orderController.GetAllOrdersFiltrated(status: "Done");
            //foreach (Order ord in orders)
            //{
            //    Console.WriteLine(ord.Status);
            //}


        }


        private static List<Order> mockOrders()
        {
            List<Order> output = new List<Order>
            {
                new Order{ Id = 1, Status = "NotStarted", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 1 },
                new Order{ Id = 2, Status = "Loading", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 2 },
                new Order{ Id = 3, Status = "InProgress", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 3 },
                new Order{ Id = 4, Status = "Arrived", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 4 },
                new Order{ Id = 5, Status = "Unloading", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 1 },
                new Order{ Id = 6, Status = "Cancelled", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 1 },
                new Order{ Id = 7, Status = "Done", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, ProductId = 1 }
            };
            return output;
        }
    }
}
