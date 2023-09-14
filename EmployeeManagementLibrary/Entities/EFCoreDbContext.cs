using EmployeeManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.Entities
{
	public class EFCoreDbContext : DbContext
	{
		
		public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options) { }

		public DbSet<EmployeeModel> Employees { get; set; }
	}
}
