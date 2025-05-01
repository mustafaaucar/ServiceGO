using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class RouteController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
