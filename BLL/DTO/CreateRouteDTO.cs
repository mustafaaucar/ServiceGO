using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CreateRouteDTO
    {
        public int Id { get; set; } 
        public string RouteName { get; set; }//
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public TimeSpan MorningStartTime { get; set; }
        public TimeSpan EveningStartTime { get; set; }
        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }
        public string Plate { get; set; }//
        public int SeatNumber { get; set; }
        public decimal PricePerKm { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public int DriverId { get; set; }
        public int CompanyID { get; set; }
    }
}
