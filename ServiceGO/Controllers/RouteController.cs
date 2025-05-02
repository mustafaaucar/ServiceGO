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
        private readonly IMapper _mapper;
        public RouteController(IRoutesService routeService, IMapper mapper)
        {
            _routeService = routeService;
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
                return View(routes);
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
    }
}
