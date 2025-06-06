﻿using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PassangersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal CompanyLatitude { get; set; }
        public decimal CompanyLongitude { get; set; }
        public decimal Longitude { get; set; }
        public string CitizenNumber { get; set; }
        public int? RouteId { get; set; }
        public decimal? PickupLatitude { get; set; }
        public decimal? PickupLongitude { get; set; }
        public int WalkingDistanceInMeters { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
