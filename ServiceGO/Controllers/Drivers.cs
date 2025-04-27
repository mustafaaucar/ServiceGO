using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ServiceGO.Controllers
{
    public class Drivers : Controller
    {
        private readonly ILogger<Drivers> _logger;
        private readonly IDriversService _driversService;

        public Drivers(ILogger<Drivers> logger, IDriversService driversService)
        {
            _logger = logger;
            _driversService = driversService;

        }



        [Authorize]
        public async Task<IActionResult> Index()
        {
            var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CompanyID");

            if (companyIdClaim == null)
            {
                return Unauthorized(); 
            }

            int companyID = int.Parse(companyIdClaim.Value);

            var drivers = await _driversService.GetAllDriversByCompanyAsync(companyID, 0 , 10);
            return View(drivers);
        }
    }
}
