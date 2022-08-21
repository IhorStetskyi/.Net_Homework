using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace MyWebApplication.Models
{
    public class Category
    {
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        private readonly IConfiguration _configuration;
        public Category(IConfiguration conf)
        {
            _configuration = conf;
        }
        public Category()
        {
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
