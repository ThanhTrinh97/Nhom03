using Microsoft.AspNetCore.Mvc;
using Nhom03.Data;

namespace Nhom03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        private readonly Nhom03Context _context;

        public LoginController(Nhom03Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]

        public IActionResult Login(string Username, string Password)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.Username == Username && a.Password == Password);
            
            if (acc != null && acc.IsAdmin == true)
            {
                var id = acc.Id;
                var fullname = acc.FullName;
                var avatar = acc.Avatar;
                var checkLogin = 1;
                HttpContext.Session.SetInt32("checkLogin", checkLogin);
                HttpContext.Session.SetInt32("id", id);
                HttpContext.Session.SetString("fullname", fullname);
                HttpContext.Session.SetString("avatar", avatar);
                HttpContext.Session.SetString("username", Username);
                return RedirectToAction("Index", "Home");
             

            }
            else
            {
                ViewBag.ErrorMsg = "Đăng nhập thất bại!";
                return RedirectToAction("Index", "Login");

            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}
