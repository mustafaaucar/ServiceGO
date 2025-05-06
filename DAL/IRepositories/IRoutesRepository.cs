using DAL.IRepository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IRoutesRepository : IBaseRepository<Route>
    {
        Task<List<Route>> GetDriverRoutes(int driverID);
        Task<List<Route>> GetCompanyRoutes(int companyID);
        Task<Route> GetRoutePassangers(int routeID);
        Task<Route> GetRouteDetails(int routeID);
        Task<List<RouteWaypoint>> GetRoutePins(int routeID);
    }
}
