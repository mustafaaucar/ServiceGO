using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Helpers
{
    public static class RouteOptimizationHelper
    {
        private const decimal MaxWalkingDistanceMeters = 1000;
        private const decimal AverageVehicleSpeedMps = 8.33M;

        /// <summary>
        /// Yolcu pickup noktalarını değerlendirir ve optimize eder.
        /// Ardından yolcu sırasını optimize eder.
        /// </summary>
        public static void OptimizeRoute(Route route)
        {
            foreach (var passenger in route.Passengers)
            {
                if (passenger.Latitude == 0 || passenger.Longitude == 0)
                    continue;

                var lastWaypoint = route.Waypoints?
                    .OrderBy<RouteWaypoint, int>(w => w.StopOrder)
                    .LastOrDefault();

                if (lastWaypoint == null)
                {
                    lastWaypoint = new RouteWaypoint
                    {
                        Latitude = route.StartLatitude,
                        Longitude = route.StartLongitude
                    };
                }

                decimal homeDistance = Haversine(
                    lastWaypoint.Latitude, lastWaypoint.Longitude,
                    passenger.Latitude, passenger.Longitude);

                decimal timeToHome = homeDistance / AverageVehicleSpeedMps;

                decimal altLat = passenger.PickupLatitude ?? passenger.Latitude;
                decimal altLon = passenger.PickupLongitude ?? passenger.Longitude;

                decimal altDistance = Haversine(
                    lastWaypoint.Latitude, lastWaypoint.Longitude,
                    altLat, altLon);

                decimal timeToAlt = altDistance / AverageVehicleSpeedMps;

                decimal walkDistance = Haversine(
                    passenger.Latitude, passenger.Longitude,
                    altLat, altLon);

                if ((timeToHome - timeToAlt) > 600 && walkDistance <= MaxWalkingDistanceMeters)
                {
                    passenger.UseAlternatePickup = true;
                }
                else
                {
                    passenger.UseAlternatePickup = false;
                }
            }

            ReorderPassengersByNearestNeighbor(route);
        }

        /// <summary>
        /// Yolcuları servise alınacak en yakın mantıklı sıraya göre dizer.
        /// </summary>
        public static void ReorderPassengersByNearestNeighbor(Route route)
        {
            var ordered = new List<Passangers>();
            var unvisited = new List<Passangers>(route.Passengers);

            decimal currentLat = route.StartLatitude;
            decimal currentLon = route.StartLongitude;

            while (unvisited.Any())
            {
                var nearest = unvisited
                    .OrderBy<Passangers, decimal>(p =>
                        Haversine(
                            currentLat,
                            currentLon,
                            p.UseAlternatePickup ? p.PickupLatitude ?? p.Latitude : p.Latitude,
                            p.UseAlternatePickup ? p.PickupLongitude ?? p.Longitude : p.Longitude
                        )
                    )
                    .First();

                ordered.Add(nearest);
                unvisited.Remove(nearest);

                currentLat = nearest.UseAlternatePickup ? nearest.PickupLatitude ?? nearest.Latitude : nearest.Latitude;
                currentLon = nearest.UseAlternatePickup ? nearest.PickupLongitude ?? nearest.Longitude : nearest.Longitude;
            }

            route.Passengers = ordered;
        }

        /// <summary>
        /// Yolculara göre sıralı şekilde duraklar (RouteWaypoint) üretir.
        /// </summary>
        public static List<RouteWaypoint> GenerateWaypointsFromPassengers(Route route)
        {
            var waypoints = new List<RouteWaypoint>();
            int order = 1;

            foreach (var passenger in route.Passengers)
            {
                decimal lat = passenger.UseAlternatePickup && passenger.PickupLatitude.HasValue
                    ? passenger.PickupLatitude.Value
                    : passenger.Latitude;

                decimal lon = passenger.UseAlternatePickup && passenger.PickupLongitude.HasValue
                    ? passenger.PickupLongitude.Value
                    : passenger.Longitude;

                waypoints.Add(new RouteWaypoint
                {
                    RouteId = route.Id,
                    Latitude = lat,
                    Longitude = lon,
                    Address = passenger.Address,
                    StopOrder = order++
                });
            }

            return waypoints;
        }

        /// <summary>
        /// İki koordinat arası kuş uçuşu mesafeyi metre cinsinden hesaplar.
        /// </summary>
        public static decimal Haversine(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            double R = 6371000;

            double dLat = (double)(lat2 - lat1) * Math.PI / 180.0;
            double dLon = (double)(lon2 - lon1) * Math.PI / 180.0;

            double lat1Rad = (double)lat1 * Math.PI / 180.0;
            double lat2Rad = (double)lat2 * Math.PI / 180.0;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = R * c;

            return (decimal)distance;
        }
    }
}
