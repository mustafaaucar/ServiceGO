using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRoutesService _routeService;
        private readonly IDriversService _driversService;
        private readonly IMapper _mapper;
        public RouteController(IRoutesService routeService, IMapper mapper, IDriversService driversService)
        {
            _routeService = routeService;
            _driversService = driversService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var listPermission = User.Claims.FirstOrDefault(c => c.Type == "ListPermission");
            if (listPermission != null && Convert.ToBoolean(listPermission.Value) == true)
            {
                var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CompanyID");
                int companyID = int.Parse(companyIdClaim.Value);
                var routes = await _routeService.GetCompanyRoutes(companyID);
                var drivers = await _driversService.GetAllDriversByCompanyAsync(companyID);
                RouteIndexDTO routeIndexDTO = new RouteIndexDTO
                {
                    Routes = routes,
                    Drivers = drivers.Items.ToList(),
                };
                return View(routeIndexDTO);
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRoute(CreateRouteDTO model)
        {
            var addPermission = User.Claims.FirstOrDefault(c => c.Type == "AddPermission");
            if (addPermission != null && Convert.ToBoolean(addPermission.Value) == true)
            {
                var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CompanyID");
                int companyID = int.Parse(companyIdClaim.Value);
                model.CompanyID = companyID;
                await _routeService.CreateRoute(model);
            }
            return Ok();
        }
    }
}
