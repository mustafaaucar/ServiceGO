using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Payment : BaseEntity
    {
        public int IBAN { get; set; }
        public string BankName { get; set; }
        public string LastUsageDay { get; set; }
        public string CVV { get; set; }
    }
}
