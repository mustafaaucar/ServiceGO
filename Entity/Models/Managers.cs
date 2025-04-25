using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Managers : BaseEntity
    {
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerTel { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public bool AddPermission { get; set; }
        public bool UpdatePermission { get; set; }
        public bool DeletePermission { get; set; }
        public bool ListPermission { get; set; }


    }
}
