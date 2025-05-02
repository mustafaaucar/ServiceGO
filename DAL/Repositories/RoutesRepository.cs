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
    public class RoutesRepository : BaseRepository<Route>, IRoutesRepository
    {
        private readonly AppDbContext _context;
        public RoutesRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Route>> GetCompanyRoutes(int companyID)
        {
            var routeList = await(from r in _context.Routes 
                                      join cd in _context.CompanyDrivers on r.Id equals cd.RouteID
                                      join c in _context.Companies on cd.CompanyID equals c.Id
                                      where c.Id == companyID
                                      select r).ToListAsync();
            return routeList;
        }

        public async Task<List<Route>> GetDriverRoutes(int driverID)
        {
            try
            {
                var routes = await (from route in _context.Routes
                              join companyDrivers in _context.CompanyDrivers on route.Id equals companyDrivers.RouteID
                              join driver in _context.Drivers on companyDrivers.DriverID equals driver.Id
                              where companyDrivers.DriverID == driverID
                              select route
                              ).ToListAsync();

                return routes;

            }
            catch (Exception)
            {
                var routes = new List<Route>();
                return routes;
            }
        }
    }
}
