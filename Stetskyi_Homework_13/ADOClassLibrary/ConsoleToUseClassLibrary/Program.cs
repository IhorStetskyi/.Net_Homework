using System;
using System.Collections.Generic;
using ADOClassLibrary.InjectionsFolder;
using ADOClassLibrary.Interfaces;
using ADOClassLibrary.Models;
using ADOClassLibrary.StaticClasses;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleToUseClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider container = Startup.ConfigureService();
            IPerformer performer = container.GetRequiredService<IPerformer>();

            performer.DeleteStoredProcedures();
            performer.CreateStoredProcedures();
            performer.UpdateDB();

            ToTest(performer);

        }

        static void ToTest(IPerformer performer)
        {
            List<Product> products = performer.GetAllProducts();
            List<Order> orders = performer.GetAllOrders();

            #region Orders&ProductsToOperateWith
            Order orderToInsert = new Order
            {
                CreatedDate = new DateTime(2000, 1, 1),
                ProductId = 1,
                Status = "Arrived",
                UpdatedDate = DateTime.Now
            };

            Product productToInsert = new Product
            {
                Description = "Some Inserted Description for Product",
                Weight = 111,
                Height = 111,
                Width = 111,
                Length = 111
            };
            Order orderToUpdate = new Order
            {
                Id = 7,
                CreatedDate = new DateTime(2000, 1, 1),
                ProductId = 1,
                Status = "Arrived",
                UpdatedDate = DateTime.Now
            };

            Product productToUpdate = new Product
            {
                Id = 1,
                Description = "Some Updated Description for Product",
                Weight = 222,
                Height = 222,
                Width = 222,
                Length = 222
            };
            #endregion

            Console.WriteLine("Old Data:");
            products.WriteAllProducts();
            orders.WriteAllOrders();


            Console.WriteLine("\nInsertion:");
            Console.WriteLine($"Products inserted: {performer.InsertProduct(productToInsert)}");
            Console.WriteLine($"Orders inserted: {performer.InsertOrder(orderToInsert)}");
            products = performer.GetAllProducts();
            orders = performer.GetAllOrders();
            products.WriteAllProducts();
            orders.WriteAllOrders();


            Console.WriteLine("\nUpdation:");
            Console.WriteLine($"Products updated: {performer.UpdateProduct(productToUpdate)}");
            Console.WriteLine($"Orders updated: {performer.UpdateOrder(orderToUpdate)}");
            products = performer.GetAllProducts();
            orders = performer.GetAllOrders();
            products.WriteAllProducts();
            orders.WriteAllOrders();


            Console.WriteLine("\nDeletion:");
            Console.WriteLine($"Products deleted: {performer.DeleteProduct(5)}");
            Console.WriteLine($"Orders deleted: {performer.DeleteOrder(1)}");
            products = performer.GetAllProducts();
            orders = performer.GetAllOrders();
            products.WriteAllProducts();
            orders.WriteAllOrders();


            Console.WriteLine("\nFetch orders (consider filtration by month, status, year or specific product, use stored procedure):");
            orders = performer.GetAllOrders( productId: 1, status: "Arrived");
            orders.WriteAllOrders();

            Console.WriteLine("\nDelete orders (consider filtration by month, status, year or specific product, use stored procedure):");
            performer.DeleteOrders(productId: 1, status: "Arrived");
            orders = performer.GetAllOrders();
            orders.WriteAllOrders();


        }



    }
}
