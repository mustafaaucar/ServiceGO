using DAL.ApplicationDbContext;
using DAL.BaseRepository;
using DAL.IRepositories;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PassangersRepository : BaseRepository<Passangers>, IPassangerRepository
    {
        public PassangersRepository(AppDbContext context) : base(context)
        {
        }
    }
}
