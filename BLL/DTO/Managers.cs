using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ManagersDTO
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string ManagerEmail { get; set; }
        public string Password { get; set; }
        public string ManagerTel { get; set; }
        public int CompanyID { get; set; }
        public bool AddPermission { get; set; }
        public bool UpdatePermission { get; set; }
        public bool DeletePermission { get; set; }
        public bool ListPermission { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
