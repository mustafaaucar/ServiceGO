using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.IRepositories;
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
        private readonly IGeocodingService _geocodingService;
        private readonly IMapper _mapper;

        public PassangerService(IPassangerRepository pRepository, IMapper mapper, IGeocodingService geocodingService)
        {
            _pRepository = pRepository;
            _mapper = mapper;
            _geocodingService = geocodingService;
        }

        public async Task AddPassangersAsync(PassangersDTO model)
        {
            model.IsActive = true;
            if (model.RouteId == 0)
            {
                model.RouteId = null;
            }
            await _pRepository.AddAsync(_mapper.Map<Passangers>(model));
        }

        public async Task<IEnumerable<PassangersDTO>> GetCompanyPassangers(int companyID)
        {
            var passangerList = await _pRepository.GetCompanyPassangers(companyID);
            return _mapper.Map<List<PassangersDTO>>(passangerList);
        }
    }
}
