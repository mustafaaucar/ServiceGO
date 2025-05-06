using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
	public class Passangers : BaseEntity
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; } 
        public decimal Longitude { get; set; }
        public string CitizenNumber { get; set; }
        public decimal? PickupLatitude { get; set; }
        public decimal? PickupLongitude { get; set; }
        public int WalkingDistanceInMeters { get; set; }
        public bool UseAlternatePickup { get; set; } = false;
        public int? RouteId { get; set; }
        public Route? Route { get; set; }
    }
}
