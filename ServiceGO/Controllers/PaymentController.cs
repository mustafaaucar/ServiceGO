using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceGO.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ICompanyDriversService _cdService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper, ICompanyDriversService cdService)
        {
            _paymentService = paymentService;
            _cdService = cdService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdatePayment(PaymentDTO model)
        {
            var updatePermission = User.Claims.FirstOrDefault(c => c.Type == "UpdatePermission");
            if (updatePermission != null && Convert.ToBoolean(updatePermission.Value) == true)
            {
                try
                {
                    await _paymentService.UpdateAsync(model);
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPayment(CreatePaymentDTO model)
        {
            var addPermission = User.Claims.FirstOrDefault(c => c.Type == "AddPermission");
            var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == "CompanyID");
            model.CompanyID = int.Parse(companyIdClaim.Value);
            if (addPermission != null && Convert.ToBoolean(addPermission.Value))
            {
                try
                {
                    PaymentDTO payment = new PaymentDTO
                    {
                        BankName = model.BankName,
                        CreatedDate = DateTime.Now,
                        CVV = model.CVV,
                        IBAN = model.IBAN,
                        IsActive = true,
                        LastUsageDay = model.LastUsageDay,
                        ModifiedDate = DateTime.Now,
                    };
                    var newPayment = await _paymentService.AddPaymentAsync(payment);

                    CompanyDriversDTO cd = new CompanyDriversDTO
                    {
                        DriverID = model.DriverID,
                        CompanyID = model.CompanyID,
                        RouteID = null,
                        PaymentID = newPayment.Id,
                    };
                    var newCd = await _cdService.AddCompanyDriver(_mapper.Map<CompanyDriversDTO>(cd));  
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Sunucu hatası: {ex.Message}");
                }
            }
            else
            {
                return BadRequest("Yetkiniz yok.");
            }
        }

    }
}
