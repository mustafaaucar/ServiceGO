using DAL.ApplicationDbContext;
using DAL.BaseRepository;
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
    public class DriversRepository : BaseRepository<Drivers>, IDriversRepository
    {
        private readonly DbSet<Drivers> _dbSet;
        private readonly AppDbContext _context;

        public DriversRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Drivers>();
        }

        public async Task<IEnumerable<Drivers>> GetCompanyDrivers(int companyID)
        {
            var driverIds = new List<int>();
            try
            {
                var drivers = await (from route in _context.Routes
                                     join driver in _dbSet on route.DriverID equals driver.Id
                                     where route.IsActive && driver.IsActive && route.CompanyID == companyID
                                     select driver)
                         .Distinct()
                         .ToListAsync();

                return drivers;
            }
            catch (Exception)
            {
                if (!driverIds.Any())
                {
                    return new List<Drivers>(); 
                }
                throw;
            }
        }
    }
}
