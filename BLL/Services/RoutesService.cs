using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.IRepositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoutesService : IRoutesService
    {
        private readonly IMapper _mapper;
        private readonly IRoutesRepository _routesRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IPassangerRepository _passangerRepository;
        private readonly ICompanyDriversRepository _companyDriversRepository;

        public RoutesService(IRoutesRepository routesRepository, IMapper mapper, ICompaniesRepository companiesRepository, ICompanyDriversRepository companyDriversRepository,IPassangerRepository passangerRepository)
        {
            _routesRepository = routesRepository;
            _companiesRepository = companiesRepository;
            _mapper = mapper;
            _companyDriversRepository = companyDriversRepository;
            _passangerRepository = passangerRepository;
        }

        public async Task<List<RouteDto>> GetCompanyRoutes(int companyID)
        {
            var routes = await _routesRepository.GetCompanyRoutes(companyID);
            return _mapper.Map<List<RouteDto>>(routes);
        }

        public async Task<List<RouteDto>> GetDriverRoutes(int driverID)
        {
            var routes = await _routesRepository.GetDriverRoutes(driverID);
            return _mapper.Map<List<RouteDto>>(routes);
        }

        public async Task<bool> CreateRoute(int companyID)
        {
            return true;
        }

        public async Task<bool> CreateRoute(CreateRouteDTO model)
        {
            try
            {
                var company = await _companiesRepository.GetByIdAsync((int)model.CompanyID);
                RouteDto routeDto = new RouteDto
                {
                    RouteName = model.RouteName,
                    CreatedDate = DateTime.Now,
                    EveningStartTime = model.EveningStartTime ?? TimeSpan.Zero,
                    EndLongitude = model.RouteType == true ? company.Longitude : 0,
                    EndLatitude = model.RouteType == true ? company.Latitude : 0,
                    CurrentLongitude = model.CurrentLongitude ?? 0,
                    CurrentLatitude = model.CurrentLatitude ?? 0,
                    IsActive = true,
                    RouteType = model.RouteType,
                    ModifiedDate = DateTime.Now,
                    MorningStartTime = model.MorningStartTime ?? TimeSpan.Zero,
                    Plate = model.Plate,
                    PricePerKM = model.PricePerKm.ToString(),
                    SeatNumber = model.SeatNumber ?? 0,
                    StartLatitude = model.RouteType == false ? company.Latitude : 0,
                    StartLongitude = model.RouteType == false ? company.Longitude : 0,
                };

                var route = await _routesRepository.AddAsync(_mapper.Map<Route>(routeDto));

                var cd = await _companyDriversRepository.GetCompanyDrivers((int)model.DriverId, (int)model.CompanyID);
                if (cd.Where(x => x.RouteID == null).ToList().Count() == 0)
                {
                    var updated = cd.FirstOrDefault();
                    updated.RouteID = route.Id;
                    await _companyDriversRepository.UpdateAsync(updated);
                }
                else
                {
                    CompanyDrivers cd2 = new CompanyDrivers
                    {
                        DriverID = (int)model.DriverId,
                        CompanyID = (int)model.CompanyID,
                        IsActive = true,
                        ModifiedDate = DateTime.Now,
                        PaymentID = cd.FirstOrDefault().PaymentID,
                        RouteID = route.Id,
                        CreatedDate = DateTime.Now,
                    };
                    await _companyDriversRepository.AddAsync(cd2);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<RouteDetailPageDTO> GetRouteDetails(int routeID)
        {
            try
            {
                RouteDetailPageDTO routeDetailPageDTO = new RouteDetailPageDTO();

                var route = await _routesRepository.GetRouteDetails(routeID);
                var passangers = await _passangerRepository.GetRoutePassangers(routeID);
                var pins = await _routesRepository.GetRoutePins(routeID);

                routeDetailPageDTO.RouteWaypoint = _mapper.Map<List<RouteWaypointDTO>>(pins);
                routeDetailPageDTO.PassangerList = _mapper.Map<List<PassangersDTO>>(passangers);
                routeDetailPageDTO.Routes = _mapper.Map<RouteDto>(route);

                return routeDetailPageDTO;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
