using Microsoft.AspNetCore.Mvc;

namespace GeziRehberim.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

