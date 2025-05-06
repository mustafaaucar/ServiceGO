using AutoMapper;
using BLL.DTO;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.IRepositories;
using DAL.Repositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PassangerService : IPassangerService
    {
        private readonly IPassangerRepository _pRepository;
        private readonly IRoutesRepository _routeRepository;
        private readonly IRouteWaypointsRepository _routeWaypointRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public PassangerService(IPassangerRepository pRepository, IMapper mapper, IRoutesRepository routesRepository, IRouteWaypointsRepository routeWaypointRepository, IManagerRepository managerRepository)
        {
            _pRepository = pRepository;
            _mapper = mapper;
            _routeRepository = routesRepository;
            _routeWaypointRepository = routeWaypointRepository;
            _managerRepository = managerRepository;
        }

        public async Task AddPassangersAsync(PassangersDTO model)
        {
            model.IsActive = true;
            if (model.RouteId == 0)
            {
                model.RouteId = null;
            }
            Passangers passangers = new Passangers
            {
                Address = model.Address,
                CitizenNumber = model.CitizenNumber,
                CreatedDate = DateTime.Now,
                Email = model.Email,
                IsActive = true,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                ModifiedDate = DateTime.Now,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                PickupLatitude = model.PickupLatitude,
                PickupLongitude = model.PickupLongitude,
                RouteId = model.RouteId,
                Surname = model.Surname,
                WalkingDistanceInMeters = model.WalkingDistanceInMeters,
            };
            var newPassenger = passangers;
            await _pRepository.AddAsync(newPassenger);

            if (model.RouteId.HasValue)
            {
                var route = await _routeRepository.GetRoutePassangers(model.RouteId.Value);
                if (route == null) return;

                RouteOptimizationHelper.OptimizeRoute(route);

                var newWaypoints = RouteOptimizationHelper.GenerateWaypointsFromPassengers(route);

                var isDeleted = await _routeWaypointRepository.DeleteByRouteIdAsync(route.Id);
                if (isDeleted)
                {
                    await _routeWaypointRepository.AddRangeAsync(newWaypoints);
                }
            }
        }

        public async Task<IEnumerable<PassangersDTO>> GetCompanyPassangers(int companyID)
        {
            var passangerList = await _pRepository.GetCompanyPassangers(companyID);
            return _mapper.Map<List<PassangersDTO>>(passangerList);
        }
    }
}
