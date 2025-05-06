using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PickupPointResult
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int WalkingDistanceMeters { get; set; }
        public string EstimatedWalkingTimeText { get; set; } 
    }
}
