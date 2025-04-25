using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.IRepositories;
using DAL.IRepository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IMapper _mapper;

        public CompaniesService(ICompaniesRepository companiesRepository, IMapper mapper)
        {
            _companiesRepository = companiesRepository;
            _mapper = mapper;
        }
        public async Task<CompaniesDTO> AddCompany(CompaniesDTO model)
        {
            model.IsActive = true;
            var entry = await _companiesRepository.AddAsync(_mapper.Map<Companies>(model));
            await _companiesRepository.SaveAsync();
            return _mapper.Map<CompaniesDTO>(entry);
        }

        
    }
   
}
