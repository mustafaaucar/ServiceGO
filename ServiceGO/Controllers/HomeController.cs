using BLL.DTO;
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
        private readonly ICompaniesService _companiesService;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IDriversService driversService, IAuthService authService, ICompaniesService companiesService)
		{
			_logger = logger;
            _driversService = driversService;
            _authService = authService;
            _companiesService = companiesService;
        }

        public IActionResult Index()
		{
            var drivers = _driversService.GetAllDriversAsync().Result;
            return View(drivers);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            _authService.LoginAsync(model);
            return Ok();
        }
        public IActionResult Register(CompaniesDTO? model)
        {
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>Register(ManagersDTO model)
        {
            await _authService.RegisterAsync(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RegisterCompany(CompaniesDTO model)
        {
            var entry = await _companiesService.AddCompany(model);
            return RedirectToAction("Register", entry);
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}
