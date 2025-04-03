using DAL.ApplicationDbContext;
using DAL.IRepositories;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class DriversRepository : IDriversRepository
	{
		private readonly AppDbContext _context;

		public DriversRepository(AppDbContext context) 
		{ 
			_context = context;
		}
		public async Task AddAsync(Drivers entity)
		{
			await _context.AddAsync(entity);
		}

		public void Delete(Drivers entity)
		{
			_context.Remove(entity);	
		}



		public async Task<IEnumerable<Drivers>> GetAllAsync()
		{
			return await _context.Drivers.ToListAsync();
		}

		public async Task<Drivers> GetByIdAsync(int id)
		{
			return await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task SaveAsync()
		{
			await SaveAsync();
		}

		public void Update(Drivers entity)
		{
			_context.Update(entity);
		}

	
	}
}
