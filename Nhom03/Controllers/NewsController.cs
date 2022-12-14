using Microsoft.AspNetCore.Mvc;

namespace Nhom03.Controllers
{
	public class NewsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
