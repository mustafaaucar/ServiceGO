using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ApplicationDbContext
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Drivers> Drivers { get; set; }
		public DbSet<Passangers> Passangers { get; set; }
		public DbSet<Route> Routes { get; set; }
		public DbSet<Companies> Companies { get; set; }
		public DbSet<Managers> Managers { get; set; }
		public DbSet<CompanyDrivers> CompanyDrivers{ get; set; }
		public DbSet<Payment> Payment{ get; set; }
	}
}
