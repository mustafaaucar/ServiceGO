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
            var passangerList = await (from p in _context.Passangers
                                 join r in _context.Routes on p.RouteId equals r.Id
                                 join cd in _context.CompanyDrivers on r.Id equals cd.RouteID
                                 join c in _context.Companies on cd.CompanyID equals c.Id
                                 where c.Id == companyID
                                 select p).ToListAsync();
            return passangerList;
        }
    }
}
