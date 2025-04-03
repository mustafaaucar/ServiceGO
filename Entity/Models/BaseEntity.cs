using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
	public class BaseEntity
	{
		public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
		public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } 
    }
}
