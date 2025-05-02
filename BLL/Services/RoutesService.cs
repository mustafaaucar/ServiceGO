using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.IRepositories;
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

        public RoutesService(IRoutesRepository routesRepository, IMapper mapper)
        {
            _routesRepository = routesRepository;
            _mapper = mapper;
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
    }
}
