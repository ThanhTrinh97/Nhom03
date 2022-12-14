using Microsoft.AspNetCore.Mvc;

namespace Nhom03.Controllers
{
	public class ContactsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
