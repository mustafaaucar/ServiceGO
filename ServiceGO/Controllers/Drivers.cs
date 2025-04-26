using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class Drivers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
