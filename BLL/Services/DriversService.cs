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
	public class DriversService : IDriversService
	{
		private readonly IDriversRepository _driversRepository;
		private readonly IMapper _mapper;

		public DriversService(IDriversRepository driversRepository, IMapper mapper)
		{
			_driversRepository = driversRepository;
			_mapper = mapper;
		}

        public DriversService()
        {
        }

        public async Task<IEnumerable<DriversDTO>> GetAllDriversAsync()
		{
			var drivers = await _driversRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<DriversDTO>>(drivers);
		}

		public async Task<DriversDTO> GetDriverByIdAsync(int id)
		{
			var driver = await _driversRepository.GetByIdAsync(id);
			return _mapper.Map<DriversDTO>(driver);
		}

		public async Task AddDriverAsync(DriversDTO driverDto)
		{
			var driver = _mapper.Map<Drivers>(driverDto);
			await _driversRepository.AddAsync(driver);
		}

		public async Task UpdateDriverAsync(DriversDTO driverDto)
		{
			var driver = _mapper.Map<Drivers>(driverDto);
			_driversRepository.Update(driver);
		}

		public async Task DeleteDriverAsync(int id)
		{
			var driver = await _driversRepository.GetByIdAsync(id);
			if (driver != null)
			{
				_driversRepository.Delete(driver);
			}
		}
	}
}
