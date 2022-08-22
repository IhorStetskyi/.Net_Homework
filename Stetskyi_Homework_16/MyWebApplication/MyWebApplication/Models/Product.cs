using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.Models
{
    public class Product
    {
        [Required(ErrorMessage = "ProductID is required")]
        public int ProductID { get; set; }
        [StringLength(30)]
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public string QuantityPerUnit { get; set; }
        [Range(1, 10000, ErrorMessage = "Price must be between $1 and $10000")]
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int Discontinued { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public Category category { get { return new Category { CategoryID = this.CategoryID, CategoryName = this.CategoryName }; } set { category = value; } }



    }
}
