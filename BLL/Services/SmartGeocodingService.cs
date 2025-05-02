using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
namespace BLL.Services
{
    public class SmartGeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClient;

        public SmartGeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       
    }
}
