using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RouteDetailPageDTO
    {
        public RouteDto Routes { get; set; }
        public List<PassangersDTO> PassangerList { get; set; }
        public List<RouteWaypointDTO> RouteWaypoint { get; set; }
    }
}
