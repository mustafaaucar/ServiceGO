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
    public class CompanyDriversService : ICompanyDriversService
    {
        private readonly ICompanyDriversRepository _cdRepository;
        private readonly IMapper _mapper;

        public CompanyDriversService(ICompanyDriversRepository cdRepository, IMapper mapper)
        {
            _cdRepository = cdRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddCompanyDriver(CompanyDriversDTO driver)
        {
            try
            {
                await _cdRepository.AddAsync(_mapper.Map<CompanyDrivers>(driver));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
