using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PickupPointResult
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int WalkingDistanceMeters { get; set; }
        public string EstimatedWalkingTimeText { get; set; } 
    }
}
