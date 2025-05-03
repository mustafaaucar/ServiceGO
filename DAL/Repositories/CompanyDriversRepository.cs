using DAL.ApplicationDbContext;
using DAL.BaseRepository;
using DAL.IRepositories;
using DAL.IRepository;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CompanyDriversRepository : BaseRepository<CompanyDrivers> , ICompanyDriversRepository
    {
        private readonly AppDbContext _context;
        public CompanyDriversRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CompanyDrivers>> GetCompanyDrivers(int driverID, int companyID)
        {
            try
            {
                var cd = await _context.CompanyDrivers.Where(x => x.DriverID == driverID && x.CompanyID == companyID).ToListAsync();
                return cd;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
  
}
