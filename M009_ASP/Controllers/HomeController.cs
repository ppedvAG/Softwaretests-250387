using Microsoft.AspNetCore.Mvc;

namespace M009_ASP.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
	[FromQuery]
	public int Counter { get; set; }

	public IActionResult Index()
	{
		return View(Counter);
	}

	[HttpPost]
	public IActionResult CounterPlusPlus(int zahl)
	{
		return RedirectToAction("Index", new { Counter = zahl + 1 });
	}
}
