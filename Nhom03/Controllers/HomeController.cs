using Microsoft.AspNetCore.Mvc;
using Nhom03.Data;
using Nhom03.Models;
using System.Diagnostics;

namespace Nhom03.Controllers
{
    public class HomeController : Controller
    {
		private Nhom03Context _context;
		private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Nhom03Context context)
        {
    
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.name = HttpContext.Session.GetString("fullname");
            var products = _context.Products.ToList().Where(p => p.Id <= 5);
            return View(products);
        }

        public IActionResult Privacy()
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