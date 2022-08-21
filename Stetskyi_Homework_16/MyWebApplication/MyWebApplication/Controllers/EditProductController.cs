using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Controllers
{
    public class EditProductController : Controller
    {
        private readonly IConfiguration _configuration;
        public EditProductController(IConfiguration conf)
        {
            _configuration = conf;
        }

        public IActionResult EditProductView()
        {
            return View(GetProduct(1));
        }



        public Product GetProduct(int Id)
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
                                                                                PR.Discontinued,
                                                                                PR.CategoryID,
                                                                                PR.SupplierID
                                                                                from[Products] as PR
                                                                                left join[Categories] as CAT on PR.CategoryID = CAT.CategoryID
                                                                                left join[Suppliers] as SUP on pr.SupplierID = SUP.SupplierID
                                                                                where PR.ProductID = {Id}");
                    return product;
            }
        }

        public void UpdateProduct(Product prod)
        {
            string sql = @"update [Products]
                            set ProductName = @ProductName,
                            SupplierID = @SupplierID,
                            CategoryID = @CategoryID,
                            QuantityPerUnit = @QuantityPerUnit,
                            UnitPrice = @UnitPrice,
                            UnitsInStock = @UnitsInStock,
                            ReorderLevel = @ReorderLevel,
                            Discontinued = @Discontinued
                            where ProductID = @ProductID";
            using (IDbConnection connection = new SqlConnection(_configuration["MyConfigFeature:MyConnection3"]))
            {
                connection.Execute(sql, prod);
            }
        }
    }
}
