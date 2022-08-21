using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApplication.Models;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
