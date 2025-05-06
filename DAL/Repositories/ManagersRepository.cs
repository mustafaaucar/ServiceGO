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
    public class ManagersRepository : BaseRepository<Managers>, IManagerRepository
    {
        private readonly AppDbContext _context;
        public ManagersRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Companies> GetManagersCompany(int managerID)
        {
            try
            {
                if (managerID != 0 )
                {
                    var company = await (from m in _context.Managers
                                         join c in _context.Companies on m.CompanyID equals c.Id
                                         where m.Id == managerID
                                         select c).FirstOrDefaultAsync();
                    return company;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
