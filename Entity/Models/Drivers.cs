using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
	public class Drivers : BaseEntity
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string CitizenshipNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string IdentityCardPhoto { get; set; }
        public string DriverCardPhoto { get; set; }

    }
}
