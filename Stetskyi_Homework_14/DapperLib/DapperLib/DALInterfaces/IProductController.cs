using DapperLib.Models;
using System.Collections.Generic;


namespace DapperLib.DALInterfaces
{
    public interface IProductController
    {
        public void CreateStoredProcedures();
        public void UpdateOrCreateProductsTable();

        public List<Product> GetAllProducts();
        public void InsertProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeletProduct(int productId);

    }
}
