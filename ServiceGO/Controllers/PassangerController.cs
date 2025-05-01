using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class PassangerController : Controller
    {
        private readonly IPassangerService _pService;
        public PassangerController()
        {
        }

        [Authorize]
        public IActionResult Index()
        {

            return View();
        }
    }
}
