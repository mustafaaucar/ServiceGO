using DAL.IRepository;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IRouteWaypointsRepository : IBaseRepository<RouteWaypoint>
    {
        Task<bool> DeleteByRouteIdAsync(int id);
        Task<bool> AddRangeAsync(List<RouteWaypoint> entity);
    }
}
