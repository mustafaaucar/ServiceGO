using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RouteIndexDTO
    {
        public List<RouteDto> Routes { get; set; }
        public List<DriversDTO> Drivers { get; set; }
    }
}
