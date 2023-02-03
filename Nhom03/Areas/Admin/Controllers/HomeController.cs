using Microsoft.AspNetCore.Mvc;

namespace Nhom03.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            ViewBag.user = HttpContext.Session.GetString("username");
            return View();
        }
        
    }
}
