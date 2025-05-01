using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class CompanyDrivers : BaseEntity
    {
        public int CompanyID { get; set; }
        public Companies Company { get; set; }
        public int DriverID { get; set; }
        public Drivers Driver { get; set; }
        public int? RouteID { get; set; }
        public Route Route { get; set; }
        public int? PaymentID { get; set; }
        public Payment Payment { get; set; }
    }
}
