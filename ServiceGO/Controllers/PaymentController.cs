using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdatePayment(PaymentDTO model)
        {
            var updatePermission = User.Claims.FirstOrDefault(c => c.Type == "UpdatePermission");
            if (updatePermission != null && Convert.ToBoolean(updatePermission.Value) == true)
            {
                try
                {
                    _paymentService.UpdateAsync(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return Ok();
                    throw;
                }
            }
            else
            {
                return BadRequest("Yetkiniz yok.");
            }
        }
    }
}
