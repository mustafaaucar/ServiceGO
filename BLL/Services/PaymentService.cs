using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.IRepositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task<List<PaymentDTO>> GetPayment(int driverID, int companyID)
        {
            var payments = await _paymentRepository.GetPayment(driverID, companyID);
            return _mapper.Map<List<PaymentDTO>>(payments);
        }

        public void UpdateAsync(PaymentDTO model)
        {
            if (model.Id != 0)
            {
                _paymentRepository.Update(_mapper.Map<Payment>(model));
            }
        }
    }
}
