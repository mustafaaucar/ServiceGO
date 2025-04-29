using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<PaymentDTO> GetPayment(int driverID, int companyID)
        {
            throw new NotImplementedException();
        }
    }
}
