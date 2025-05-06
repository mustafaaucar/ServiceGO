using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Entity.Models
{
	public class Route : BaseEntity
	{

        public string RouteName { get; set; }
        public decimal StartLatitude { get; set; }
        public decimal StartLongitude { get; set; }
        public decimal EndLatitude { get; set; }
        public decimal EndLongitude { get; set; }
        public TimeSpan MorningStartTime { get; set; }
        public TimeSpan EveningStartTime { get; set; }
        public decimal CurrentLatitude { get; set; }
        public decimal CurrentLongitude { get; set; }
        public bool RouteType { get; set; } // true = işe gidiş / false = işten geliş
        public string Plate { get; set; }
        public int SeatNumber { get; set; }
        public decimal PricePerKm { get; set; }
        public ICollection<Passangers> Passengers { get; set; }
        public ICollection<RouteWaypoint> Waypoints { get; set; }
    }
}
