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
    public class CompaniesRepository : BaseRepository<Companies>, ICompaniesRepository
    {
        public CompaniesRepository(AppDbContext context) : base(context)
        {
        }
    }

}
