using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Category _category;
        public CategoryController(Category cat)
        {
            _category = cat;
        }
        public IActionResult Categories()
        {
            return View("Categories", _category.categoryList());
        }
    }
}
