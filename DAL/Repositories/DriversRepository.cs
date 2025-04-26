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
        public DriversRepository(AppDbContext context) : base(context)
        {
        }
    }
}
