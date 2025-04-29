using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int IBAN { get; set; }
        public string BankName { get; set; }
        public string LastUsageDay { get; set; }
        public string CVV { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
