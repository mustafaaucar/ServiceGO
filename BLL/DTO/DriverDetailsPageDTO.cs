using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DriverDetailsPageDTO
    {
        public DriversDTO DriverInfo { get; set; }
        public List<RouteDto> DriverRoutes { get; set; }
    }
}
