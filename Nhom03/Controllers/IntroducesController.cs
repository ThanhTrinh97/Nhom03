using Microsoft.AspNetCore.Mvc;

namespace Nhom03.Controllers
{
	public class IntroducesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
