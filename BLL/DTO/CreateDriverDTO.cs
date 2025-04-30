using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CreateDriverDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string CitizenshipNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int CompanyID { get; set; } 
        public IFormFile IdentityCardPhoto { get; set; }
        public IFormFile DriverCardPhoto { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public string IBAN { get; set; }
        public string BankName { get; set; }
        public string LastUsageDay { get; set; }
        public string CVV { get; set; }
        public DateTime PaymentCreatedDate { get; set; } = DateTime.Now;
        public DateTime PaymentModifiedDate { get; set; } = DateTime.Now;
    }
}
