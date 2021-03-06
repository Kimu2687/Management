using Attendant_check.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK
{
	public class Database_Context : DbContext
	{
		public DbSet<System_Users> System_Users { get; set; }
		public DbSet<Expenses> Expenses { get; set; }
		public DbSet<Cartons> Cartons { get; set; }
		public DbSet<Employees> Employees { get; set; }
		public DbSet<Bottles_bought> Bottles_bought { get; set; }
		public DbSet<Cartons_sold> Cartons_sold { get; set; }
		public DbSet<Monthly_sales> Monthly_sales { get; set; }

		public Database_Context(DbContextOptions<Database_Context> options)
			: base(options)
		{
		}
	}
}