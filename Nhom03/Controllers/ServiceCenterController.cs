using Microsoft.AspNetCore.Mvc;

namespace Nhom03.Controllers
{
	public class ServiceCenterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
