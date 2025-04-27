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

        public async Task<PagedResult<DriversDTO>> GetAllDriversByCompanyAsync(int companyID, int pageNumber, int pageSize)
        {
            var drivers = await _driversRepository.GetCompanyDrivers(companyID);

            var totalCount = drivers.Count(); 
            var pagedDrivers = drivers
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var pagedDriversDto = _mapper.Map<List<DriversDTO>>(pagedDrivers);

            return new PagedResult<DriversDTO>(pagedDriversDto, totalCount , pageNumber);
        }

        public async Task<DriversDTO> GetDriverByIdAsync(int id)
		{
			var driver = await _driversRepository.GetByIdAsync(id);
			return _mapper.Map<DriversDTO>(driver);
		}

		public async Task AddDriverAsync(CreateDriverDTO driverDto)
		{
            DriversDTO model = new DriversDTO();
            if (driverDto.IdentityCardPhoto != null)
            {
                var identityCardFile = driverDto.IdentityCardPhoto;
                var identityCardPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "identitycards");

                if (!Directory.Exists(identityCardPath))
                {
                    Directory.CreateDirectory(identityCardPath);
                }

                var identityCardFileName = Guid.NewGuid().ToString() + Path.GetExtension(identityCardFile.FileName);
                var identityCardFilePath = Path.Combine(identityCardPath, identityCardFileName);

                using (var stream = new FileStream(identityCardFilePath, FileMode.Create))
                {
                    await identityCardFile.CopyToAsync(stream);
                }

                model.IdentityCardPhoto = Path.Combine("uploads", "identitycards", identityCardFileName);
            }

            if (driverDto.DriverCardPhoto != null)
            {
                var driverCardFile = driverDto.DriverCardPhoto;
                var driverCardPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "drivercards");

                if (!Directory.Exists(driverCardPath))
                {
                    Directory.CreateDirectory(driverCardPath);
                }

                var driverCardFileName = Guid.NewGuid().ToString() + Path.GetExtension(driverCardFile.FileName);
                var driverCardFilePath = Path.Combine(driverCardPath, driverCardFileName);

                using (var stream = new FileStream(driverCardFilePath, FileMode.Create))
                {
                    await driverCardFile.CopyToAsync(stream);
                }

                model.DriverCardPhoto = Path.Combine("uploads", "drivercards", driverCardFileName);
            }

            model.Adress = driverDto.Adress;
            model.CreatedDate = driverDto.CreatedDate;
            model.ModifiedDate = driverDto.ModifiedDate;
            model.Birthdate = driverDto.Birthdate;
            model.CitizenshipNumber = driverDto.CitizenshipNumber;
            model.Email = driverDto.Email;
            model.Name = driverDto.Name;
            model.Surname = driverDto.Surname;
            model.PhoneNumber = driverDto.PhoneNumber;
            model.IsActive = driverDto.IsActive;


            var driver = _mapper.Map<Drivers>(model);
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

        public Task<IEnumerable<DriversDTO>> GetAllDriversAsync()
        {
            throw new NotImplementedException();
        }
    }
}
