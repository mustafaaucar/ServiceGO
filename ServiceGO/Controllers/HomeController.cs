using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Index(int companyID)
		{
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            var token = await _authService.LoginAsync(model);

            Response.Cookies.Append("ServiceGoToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });

            return Redirect("/manager-anasayfa");
        }
        [HttpGet]
        public IActionResult Register(CompaniesDTO? model)
        {
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>Register(ManagersDTO model)
        {
            await _authService.RegisterAsync(model);
            return Redirect("/login");
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
