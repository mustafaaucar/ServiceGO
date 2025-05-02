using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoutesService
    {
        Task<List<RouteDto>> GetDriverRoutes(int driverID);
        Task<List<RouteDto>> GetCompanyRoutes(int companyID);
    }
}
