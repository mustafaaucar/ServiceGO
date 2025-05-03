using DAL.IRepository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface ICompanyDriversRepository : IBaseRepository<CompanyDrivers>
    {
        Task<List<CompanyDrivers>> GetCompanyDrivers(int driverID, int companyID);

    }
}
