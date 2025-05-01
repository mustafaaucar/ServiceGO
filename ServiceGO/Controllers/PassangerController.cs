using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class PassangerController : Controller
    {
        private readonly IPassangerService _pasService;
        public PassangerController(IPassangerService passangerService)
        {
            _pasService = passangerService;
        }

        [Authorize]
        public IActionResult Index()
        {
                return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePassanger(PassangersDTO model)
        {
            var addPermission = User.Claims.FirstOrDefault(c => c.Type == "AddPermission");
            if (addPermission != null && Convert.ToBoolean(addPermission.Value) == true)
            {
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
