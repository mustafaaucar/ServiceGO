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
        public string StartCoordinats { get; set; }
        public string EndCoordinats { get; set; }
        public string MorningStartHour { get; set; }
        public string EveningStartHour { get; set; }
        public string CurrentLocation { get; set; }
        public string Plate { get; set; }
        public int SeatNumber { get; set; }
        public string PricePerKM { get; set; }
    }
}
