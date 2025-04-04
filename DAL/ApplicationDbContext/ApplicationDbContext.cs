﻿using Entity.Models;
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
		public AppDbContext(DbContextOptions<DbContext> options) : base(options) { }

		public DbSet<Drivers> Drivers { get; set; }
		public DbSet<Passangers> Passangers { get; set; }
		public DbSet<Route> Routes { get; set; }
	}
}
