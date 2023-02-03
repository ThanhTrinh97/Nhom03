using Microsoft.AspNetCore.Mvc;

namespace Nhom03.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
