using EFCHomework.DataContext;
using EFCHomework.Models;
using System.Collections.Generic;


/*
  Example of using:
  IServiceProvider container = Startup.ConfigureService();
  OrderController orderController = container.GetRequiredService<OrderController>();
            
            Insert:
            Order ord1 = new Order { Status = "a", CreatedDate = new DateTime(2010, 05, 09), UpdatedDate = new DateTime(2010, 05, 09), ProductId = 1 };
            orderController.Orders.Add(ord1);
            orderController.Sync();

            Update:
            orderController.Orders[0].Status = "Changed Status";
            orderController.Sync();

            Delete:
            orderController.Orders.Remove(orderController.Orders.Single(x => x.Id == 1));
            orderController.Sync();

 */
namespace EFCHomework.Controllers
{
    public class OrderController
    {
        private ApplicationDbContext adbContext;
        //Change List and then Sync
        public List<Order> Orders { get; set; }
        //Method to sync changes
        public void Sync()
        {
            foreach (Order order in Orders)
            {
                bool shouldBeAdded = true;
                foreach (Order order2 in adbContext.Orders)
                {
                    if (order.Id == order2.Id)
                    {
                        order2.Status = order.Status;
                        order2.CreatedDate = order.CreatedDate;
                        order2.UpdatedDate = order.UpdatedDate;
                        order2.ProductId = order.ProductId;
                        shouldBeAdded = false;
                        break;
                    }
                }
                if (shouldBeAdded)
                {
                    adbContext.Orders.Add(new Order { Status = order.Status, CreatedDate = order.CreatedDate, UpdatedDate = order.UpdatedDate, ProductId = order.ProductId });
                }
            }
            foreach (Order order1 in adbContext.Orders)
            {
                bool shouldNotBeDeleted = false;
                foreach (Order order2 in Orders)
                {
                    if(order1.Id == order2.Id)
                    {
                        shouldNotBeDeleted = true;
                    }
                }
                if (!shouldNotBeDeleted)
                {
                    adbContext.Orders.Attach(order1);
                    adbContext.Orders.Remove(order1);
                }
            }
            adbContext.SaveChanges();
            Orders = GetAllOrders();
        }

        public OrderController(ApplicationDbContext adbc)
        {
            adbContext = adbc;
            Orders = GetAllOrders();
        }
        private List<Order> GetAllOrders()
        {
            List<Order> result = new List<Order>();

            foreach (Order ord in adbContext.Orders)
            {
                result.Add(ord);
            }
            return result;
        }

    }
}
