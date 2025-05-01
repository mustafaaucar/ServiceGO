using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GoogleGeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClient;

        public GoogleGeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        {
            var encodedAddress = WebUtility.UrlEncode(address);
            
            double latitude = 0;
            double longitude = 0;

            return (latitude, longitude);

        }
    }
}
