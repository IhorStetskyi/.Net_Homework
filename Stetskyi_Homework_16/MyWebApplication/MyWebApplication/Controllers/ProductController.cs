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
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration conf)
        {
            _configuration = conf;
        }
        public IActionResult Products()
        {
            return View(productList());
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
                                                                                PR.Discontinued,
                                                                                PR.SupplierID,
                                                                                PR.CategoryID
                                                                                from[Products] as PR
                                                                                left join[Categories] as CAT on PR.CategoryID = CAT.CategoryID
                                                                                left join[Suppliers] as SUP on pr.SupplierID = SUP.SupplierID").ToList();
                return (productList, maxValue);
            }
        }
    }
}
