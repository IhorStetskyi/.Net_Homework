using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace MyWebApplication.Models
{
    public class Product
    {
        private readonly IConfiguration _configuration;
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int Discontinued { get; set; }
        public Product(IConfiguration conf)
        {
            _configuration = conf;
        }
        public Product()
        {

        }
        public (List<Product>, int maxValue) productList()
        {
            int maxValue = Convert.ToInt32(_configuration["MyConfigFeature:MaxProducts"]);
            using (IDbConnection connection = new SqlConnection(_configuration["MyConfigFeature:MyConnection3"]))
            {
                List<Product> productList = connection.Query<Product>(@"select PR.ProductID,
                                                                                PR.ProductName,
                                                                                SUP.CompanyName,
                                                                                CAT.CategoryName,
                                                                                PR.QuantityPerUnit,
                                                                                PR.UnitPrice,
                                                                                PR.UnitsInStock,
                                                                                PR.UnitsOnOrder,
                                                                                PR.ReorderLevel,
                                                                                PR.Discontinued
                                                                                from[Products] as PR
                                                                                left join[Categories] as CAT on PR.CategoryID = CAT.CategoryID
                                                                                left join[Suppliers] as SUP on pr.SupplierID = SUP.SupplierID").ToList();
                return (productList, maxValue);
            }
        }

        public Product getProductByID(int id)
        {
            using (IDbConnection connection = new SqlConnection(_configuration["MyConfigFeature:MyConnection3"]))
            {
                Product product = connection.QuerySingle<Product>(@$"select PR.ProductID,
                                                                                PR.ProductName,
                                                                                SUP.CompanyName,
                                                                                CAT.CategoryName,
                                                                                PR.QuantityPerUnit,
                                                                                PR.UnitPrice,
                                                                                PR.UnitsInStock,
                                                                                PR.UnitsOnOrder,
                                                                                PR.ReorderLevel,
                                                                                PR.Discontinued
                                                                                from[Products] as PR
                                                                                left join[Categories] as CAT on PR.CategoryID = CAT.CategoryID
                                                                                left join[Suppliers] as SUP on pr.SupplierID = SUP.SupplierID
                                                                                where PR.ProductID = {id}");
                return product;
            }
        }
       
                
    }
}
