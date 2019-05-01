using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers
{
	public class BlogController : Controller
	{
		// GET
		public IActionResult Index()
		{
			return View();
		}
	}
}