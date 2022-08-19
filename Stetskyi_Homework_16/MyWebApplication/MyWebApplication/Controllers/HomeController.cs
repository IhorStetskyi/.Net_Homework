using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using System.Configuration;
using Dapper;
using MyWebApplication.StaticFolder;
using Microsoft.Extensions.Configuration;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration conf)
        {
            _logger = logger;
            _configuration = conf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            using (IDbConnection connection = new SqlConnection(_configuration["MyConfigFeature:MyConnection3"]))
            {
                List<Category> categoryList = connection.Query<Category>("select [CategoryName] from [Categories]").ToList();
                return View("Categories", categoryList);
            }
        }

        public IActionResult Products()
        {
            using (IDbConnection connection = new SqlConnection(_configuration["MyConfigFeature:MyConnection3"]))
            {
                List<Product> categoryList = connection.Query<Product>(@"select PR.ProductID,
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
                return View("Products", categoryList);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
