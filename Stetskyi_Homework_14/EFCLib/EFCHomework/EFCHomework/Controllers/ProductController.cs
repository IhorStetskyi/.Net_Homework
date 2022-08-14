using EFCHomework.DataContext;
using EFCHomework.Models;
using System.Collections.Generic;


/*
  Example of using:
  IServiceProvider container = Startup.ConfigureService();
  ProductController productController = container.GetRequiredService<ProductController>();
            
            Insert:
            Product prod1 = new Product { Description = "New Description", Weight = 1, Height = 1, Width = 1, Length = 1 };
            productController.Products.Add(prod1);
            productController.Sync();

            Update:
            productController.Products[0].Description = "Changed Description";
            productController.Sync();

            Delete:(Looks like will perform cascade deletion!!!)
            productController.Products.Remove(productController.Products.Single(x => x.Id == 1));
            productController.Sync();

 */
namespace EFCHomework.Controllers
{
    public class ProductController
    {
        private ApplicationDbContext adbContext;

        //Change List and then Sync
        public List<Product> Products { get; set; }
        //Method to sync changes
        public void Sync()
        {
            foreach (Product product in Products)
            {
                bool shouldBeAdded = true;
                foreach (Product product2 in adbContext.Products)
                {
                    if (product.Id == product2.Id)
                    {
                        product2.Description = product.Description;
                        product2.Weight = product.Weight;
                        product2.Height = product.Height;
                        product2.Width = product.Width;
                        product2.Length = product.Length;
                        shouldBeAdded = false;
                        break;
                    }
                }
                if (shouldBeAdded)
                {
                    adbContext.Products.Add(new Product { 
                        Description = product.Description,
                        Height = product.Height,
                        Width = product.Width,
                        Weight = product.Weight,
                        Length = product.Length });
                }
            }
            foreach (Product product1 in adbContext.Products)
            {
                bool shouldNotBeDeleted = false;
                foreach (Product product2 in Products)
                {
                    if (product1.Id == product2.Id)
                    {
                        shouldNotBeDeleted = true;
                    }
                }
                if (!shouldNotBeDeleted)
                {
                    adbContext.Products.Attach(product1);
                    adbContext.Products.Remove(product1);
                }
            }
            adbContext.SaveChanges();
            Products = GetAllProducts();
        }

        public ProductController(ApplicationDbContext adbc)
        {
            adbContext = adbc;
            Products = GetAllProducts();
        }
        private List<Product> GetAllProducts()
        {
            List<Product> result = new List<Product>();

            foreach (Product prod in adbContext.Products)
            {
                result.Add(prod);
            }
            return result;
        }
    }
}
