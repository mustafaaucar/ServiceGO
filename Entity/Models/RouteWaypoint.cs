using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class RouteWaypoint : BaseEntity
    {

        public int RouteId { get; set; }
        public Route Route { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int StopOrder { get; set; } 
    }
}
