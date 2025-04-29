using BLL.DTO;
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
        private readonly IRoutesService _routesService;

        public Drivers(ILogger<Drivers> logger, IDriversService driversService, IRoutesService routesService)
        {
            _logger = logger;
            _driversService = driversService;
            _routesService = routesService;
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

            var drivers = await _driversService.GetAllDriversByCompanyAsync(companyID, 0 , 50);
            return View(drivers);
        }

        [Authorize]
        [HttpPost]
        [RequestSizeLimit(52428800)]
        public async Task<IActionResult> Create(CreateDriverDTO model)
        {
            var addPermission = User.Claims.FirstOrDefault(c => c.Type == "AddPermission");
            if (addPermission != null && Convert.ToBoolean(addPermission.Value) == true)
            {
                var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CompanyID");
                model.CompanyID = int.Parse(companyIdClaim.Value);
                await _driversService.AddDriverAsync(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [Authorize]
        public async Task<IActionResult> DriverDetail(int driverID, string name)
        {
            DriverDetailsPageDTO details = new DriverDetailsPageDTO();
            var listPermission = User.Claims.FirstOrDefault(c => c.Type == "ListPermission");
            if (listPermission != null && Convert.ToBoolean(listPermission.Value) == true)
            {
                details.DriverInfo = await _driversService.GetDriverByIdAsync(driverID);
                details.DriverRoutes = await _routesService.GetDriverRoutes(driverID);
                return View(details);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
