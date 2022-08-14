using System;
using EFCHomework;
using EFCHomework.DataContext;
using EFCHomework.InjectionFolder;
using EFCHomework.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using EFCHomework.Controllers;

namespace JustToTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider container = Startup.ConfigureService();
            OrderController orderController = container.GetRequiredService<OrderController>();
            ProductController productController = container.GetRequiredService<ProductController>();

            //Order ord = new Order { Id = 10, Status = "NotStarted", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };
            //adbContext.Products.Add(ord);
            //List<Order> orders = adbContext.Products.Where(x => x.Status == "NotStarted").ToList();
            //List<Order> ordersToUpdate = adbContext.Products.Where(x => x.Status == "Unloading").ToList();
            //foreach (Order item in orders)
            //{
            //    adbContext.Products.Attach(item);
            //    adbContext.Products.Remove(item);
            //}
            //foreach (Order item in ordersToUpdate)
            //{
            //    item.ProductId = 1;
            //}

            //adbContext.Sync();

            //Order ord1 = new Order { Status = "NotStarted", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };
            //Order ord2 = new Order { Status = "NotStarted", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };
            //Order ord3 = new Order { Status = "NotStarted", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };
            //orderController.AddOrder(ord1);
            //orderController.AddOrder(ord2);
            //orderController.AddOrder(ord3);

            //Order ord1 = new Order { Status = "a", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };
            //Order ord2 = new Order { Status = "b", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };
            //Order ord3 = new Order { Status = "c", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };

            foreach (Order item in orderController.Orders)
            {
                Console.WriteLine(item.Status);
            }

            //orderController.Products.Add(ord1);
            //orderController.Products.Add(ord2);
            //orderController.Products.Add(ord3);
            //orderController.Sync();
            //Console.WriteLine("------------");
            //foreach (Order item in orderController.Products)
            //{
            //    Console.WriteLine(item.Status);
            //}

           // orderController.Orders.Remove(orderController.Orders.Single(x => x.Status == "a"));

            orderController.Sync();
            foreach (Order item in orderController.Orders)
            {
                Console.WriteLine(item.Status);
            }

           // productController.Products.Remove(productController.Products.Single(x => x.Id == 2));
           // productController.Sync();

            foreach (Product item in productController.Products)
            {
                Console.WriteLine(item.Description);
            }

            Product prod1 = new Product { Description = "New Description", Weight = 1, Height = 1, Width = 1, Length = 1 };
            productController.Products.Add(prod1);
            productController.Sync();

            productController.Products[0].Description = "Changed Description";
            productController.Sync();

        }
    }
}
