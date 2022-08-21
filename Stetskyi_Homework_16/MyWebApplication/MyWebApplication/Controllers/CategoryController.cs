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
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        public CategoryController(IConfiguration conf)
        {
            _configuration = conf;
        }
        public IActionResult Categories()
        {
            return View(categoryList());
        }


        public List<Category> categoryList()
        {
            using (IDbConnection connection = new SqlConnection(_configuration["MyConfigFeature:MyConnection3"]))
            {
                List<Category> categoryList = connection.Query<Category>("select [CategoryName], [CategoryID] from [Categories]").ToList();
                return categoryList;
            }
        }
    }
}
