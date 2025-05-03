using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Helpers
{
    public static class RouteOptimizationHelper
    {
        private const double MaxWalkingDistanceMeters = 1000;
        private const double AverageVehicleSpeedMps = 8.33;

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

                double homeDistance = Haversine(
                    lastWaypoint.Latitude, lastWaypoint.Longitude,
                    passenger.Latitude, passenger.Longitude);

                double timeToHome = homeDistance / AverageVehicleSpeedMps;

                double altLat = passenger.PickupLatitude ?? passenger.Latitude;
                double altLon = passenger.PickupLongitude ?? passenger.Longitude;

                double altDistance = Haversine(
                    lastWaypoint.Latitude, lastWaypoint.Longitude,
                    altLat, altLon);

                double timeToAlt = altDistance / AverageVehicleSpeedMps;

                double walkDistance = Haversine(
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

            double currentLat = route.StartLatitude;
            double currentLon = route.StartLongitude;

            while (unvisited.Any())
            {
                var nearest = unvisited
                    .OrderBy<Passangers, double>(p =>
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
                double lat = passenger.UseAlternatePickup && passenger.PickupLatitude.HasValue
                    ? passenger.PickupLatitude.Value
                    : passenger.Latitude;

                double lon = passenger.UseAlternatePickup && passenger.PickupLongitude.HasValue
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
        public static double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371000;
            double dLat = (lat2 - lat1) * Math.PI / 180;
            double dLon = (lon2 - lon1) * Math.PI / 180;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
    }
}
