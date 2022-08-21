using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly Product _product;
        public ProductController(Product prod)
        {
            _product = prod;
        }
        public IActionResult Products()
        {
            return View("Products", _product.productList());
        }
        public IActionResult EditProductView()
        {
            return View("EditProductView");
        }
    }
}
