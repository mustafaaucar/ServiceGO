using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CompanyDriversDTO
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public int DriverID { get; set; }
        public int? RouteID { get; set; }
        public int? PaymentID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
