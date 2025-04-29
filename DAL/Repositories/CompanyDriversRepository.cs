using DAL.ApplicationDbContext;
using DAL.BaseRepository;
using DAL.IRepositories;
using DAL.IRepository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CompanyDriversRepository : BaseRepository<CompanyDrivers> , ICompanyDriversRepository
    {
        public CompanyDriversRepository(AppDbContext context) : base(context)
        {
        }

     
    }
  
}
