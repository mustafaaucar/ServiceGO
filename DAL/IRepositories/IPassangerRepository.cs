using DAL.IRepository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IPassangerRepository : IBaseRepository<Passangers>
    {
        Task<List<Passangers>> GetCompanyPassangers(int companyID);
    }
}
