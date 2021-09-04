using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK
{
	public class Database_Context : DbContext
	{

		public Database_Context(DbContextOptions<Database_Context> options)
			: base(options)
		{
		}
	}
}