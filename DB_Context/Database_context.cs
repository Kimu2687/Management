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

		public Database_Context(DbContextOptions<Database_Context> options)
			: base(options)
		{
		}
	}
}