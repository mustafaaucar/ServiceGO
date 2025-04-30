using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentDTO>> GetPayment(int driverID, int companyID);
        void UpdateAsync(PaymentDTO model);
    }
}
