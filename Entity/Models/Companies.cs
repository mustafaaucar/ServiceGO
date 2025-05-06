using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Companies : BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyEmail { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
