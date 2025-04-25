using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CompaniesDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTel { get; set; }
        public string CompanyEmail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
