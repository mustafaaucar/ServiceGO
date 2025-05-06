using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RouteDto
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public decimal StartLatitude { get; set; }
        public decimal StartLongitude { get; set; }
        public decimal EndLatitude { get; set; }
        public decimal EndLongitude { get; set; }
        public bool RouteType { get; set; }
        public TimeSpan MorningStartTime { get; set; }
        public TimeSpan EveningStartTime { get; set; }
        public decimal CurrentLatitude { get; set; }
        public decimal CurrentLongitude { get; set; }
        public string Plate { get; set; }
        public int SeatNumber { get; set; }
        public string PricePerKM { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

    }
}
