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
            IProductPerformer productPerformer = container.GetRequiredService<IProductPerformer>();
            IOrderPerformer orderPerformer = container.GetRequiredService<IOrderPerformer>();



            productPerformer.InitializeProductsDB();
            orderPerformer.InitializeOrdersDB();


            ToTest(productPerformer, orderPerformer);

        }


        static void ToTest(IProductPerformer productPerformer, IOrderPerformer orderPerformer)
        {
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

            List<Product> products = productPerformer.GetAllProducts();
            List<Order> orders = orderPerformer.GetAllOrders();
            Console.WriteLine("Old Data:");
            products.WriteAllProducts();
            orders.WriteAllOrders();



            Console.WriteLine("\nInsertion:");
            Console.WriteLine($"Products inserted: {productPerformer.InsertProduct(productToInsert)}");
            Console.WriteLine($"Orders inserted: {orderPerformer.InsertOrder(orderToInsert)}");
            products = productPerformer.GetAllProducts();
            orders = orderPerformer.GetAllOrders();
            products.WriteAllProducts();
            orders.WriteAllOrders();



            Console.WriteLine("\nUpdation:");
            Console.WriteLine($"Products updated: {productPerformer.UpdateProduct(productToUpdate)}");
            Console.WriteLine($"Orders updated: {orderPerformer.UpdateOrder(orderToUpdate)}");
            products = productPerformer.GetAllProducts();
            orders = orderPerformer.GetAllOrders();
            products.WriteAllProducts();
            orders.WriteAllOrders();



            Console.WriteLine("\nDeletion:");
            Console.WriteLine($"Products deleted: {productPerformer.DeleteProduct(5)}");
            Console.WriteLine($"Orders deleted: {orderPerformer.DeleteOrder(1)}");
            products = productPerformer.GetAllProducts();
            orders = orderPerformer.GetAllOrders();
            products.WriteAllProducts();
            orders.WriteAllOrders();



            Console.WriteLine("\nFetch orders (consider filtration by month, status, year or specific product, use stored procedure):");
            orders = orderPerformer.GetAllOrders(productId: 1, status: "Arrived");
            orders.WriteAllOrders();

            Console.WriteLine("\nDelete orders (consider filtration by month, status, year or specific product, use stored procedure):");
            orderPerformer.DeleteOrders(productId: 1, status: "Arrived");
            orders = orderPerformer.GetAllOrders();
            orders.WriteAllOrders();

        }



    }
}
