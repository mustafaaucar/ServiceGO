using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PassangerIndexDTO
    {
        public List<PassangersDTO> Passangers { get; set; }
        public List<RouteDto> Routes { get; set; }
    }
}
