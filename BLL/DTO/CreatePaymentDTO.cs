using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CreatePaymentDTO : PaymentDTO
    {
        public int DriverID { get; set; }
        public int CompanyID { get; set; }
    }
}
    