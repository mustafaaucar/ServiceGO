﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IDriversService
	{
		Task<IEnumerable<DriversDTO>> GetAllDriversAsync();
		Task<PagedResult<DriversDTO>> GetAllDriversByCompanyAsync(int companyID);

		Task<DriversDTO> GetDriverByIdAsync(int id);

		Task AddDriverAsync(CreateDriverDTO driverDto);

		Task UpdateDriverAsync(DriversDTO driverDto);

		Task DeleteDriverAsync(int id);

	}
}
