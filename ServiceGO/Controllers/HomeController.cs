using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using ServiceGO.Models;
using System.Diagnostics;

namespace ServiceGO.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IDriversService _driversService;

        public HomeController(ILogger<HomeController> logger, IDriversService driversService)
		{
			_logger = logger;
            _driversService = driversService;

        }

        public IActionResult Index()
		{
            var drivers = _driversService.GetAllDriversAsync().Result;
            return View(drivers);
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
