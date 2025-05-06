using BLL.DTO;
using BLL.Helpers;
using BLL.Interfaces;
using Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class PassangerController : Controller
    {
        private readonly IPassangerService _pasService;
        private readonly IRoutesService _routeService;
        public PassangerController(IPassangerService passangerService, IRoutesService routesService)
        {
            _pasService = passangerService;
            _routeService = routesService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            PassangerIndexDTO model = new PassangerIndexDTO();
            var listPermission = User.Claims.FirstOrDefault(c => c.Type == "ListPermission");
            if (listPermission != null && Convert.ToBoolean(listPermission.Value) == true)
            {
                var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CompanyID");
                int companyID = int.Parse(companyIdClaim.Value);
                model.Passangers = (List<PassangersDTO>)await _pasService.GetCompanyPassangers(companyID);
                model.Routes = await _routeService.GetCompanyRoutes(companyID);
                return View(model);
            }
            else
            {
                return Redirect("/Home/Login");
            }

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePassanger(PassangersDTO model)
        {
            var addPermission = User.Claims.FirstOrDefault(c => c.Type == "AddPermission");
            if (addPermission != null && Convert.ToBoolean(addPermission.Value) == true)
            {
                model.Latitude = CoordinatFixHelper.FixCoordinate(model.Latitude);
                model.Longitude = CoordinatFixHelper.FixCoordinate(model.Longitude);

                model.CompanyLatitude = decimal.Parse(User.Claims.FirstOrDefault(c => c.Type == "CompanyLatitude").Value);
                model.CompanyLongitude = decimal.Parse(User.Claims.FirstOrDefault(c => c.Type == "CompanyLongitude").Value);
                await _pasService.AddPassangersAsync(model);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
