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
    public class RouteWaypointsRepository : BaseRepository<RouteWaypoint>, IRouteWaypointsRepository
    {
        private readonly AppDbContext _context;
        public RouteWaypointsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddRangeAsync(List<RouteWaypoint> entities)
        {
            try
            {
                if (entities == null || !entities.Any())
                    return false;

                await _context.RouteWaypoints.AddRangeAsync(entities);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteByRouteIdAsync(int routeId)
        {
            try
            {
                var entities = await _context.RouteWaypoints
                    .Where(x => x.RouteId == routeId)
                    .ToListAsync();

                if (entities.Any())
                {
                    _context.RouteWaypoints.RemoveRange(entities);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
