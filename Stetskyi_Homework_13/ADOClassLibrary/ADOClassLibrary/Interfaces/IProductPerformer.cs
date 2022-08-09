using ADOClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOClassLibrary.Interfaces
{
    public interface IProductPerformer
    {
        public List<Product> GetAllProducts();
        public int InsertProduct(Product product);
        public int DeleteProduct(int productId);
        public int UpdateProduct(Product product);
        public void CreateStoredProcedures();
        public void DeleteStoredProcedures();
        public void UpdateOrCreateProductsTable();
        public void InitializeProductsDB();
    }
}
