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
    public class PassangersRepository : BaseRepository<Passangers>, IPassangerRepository
    {
        private readonly AppDbContext _context;
        public PassangersRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Passangers>> GetCompanyPassangers(int companyID)
        {
            var companyDrivers = await _context.CompanyDrivers
                .Where(cd => cd.CompanyID == companyID && cd.IsActive)
                .ToListAsync();

            var routeIds = companyDrivers
                .Where(cd => cd.RouteID.HasValue)
                .Select(cd => cd.RouteID.Value)
                .Distinct()
                .ToList();

            var passengers = await _context.Passangers
                .Where(p => p.IsActive && p.RouteId.HasValue && routeIds.Contains(p.RouteId.Value))
                .ToListAsync();

            return passengers;
        }
    }
}
