using Microsoft.AspNetCore.Mvc;

namespace AngularBlog.Controllers
{
	public class AngularController2 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
