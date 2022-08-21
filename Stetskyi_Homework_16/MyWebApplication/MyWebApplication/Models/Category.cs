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
    }
}
