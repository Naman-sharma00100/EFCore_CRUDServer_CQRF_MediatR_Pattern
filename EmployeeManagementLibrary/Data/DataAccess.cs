using EmployeeManagementLibrary.Entities;
using EmployeeManagementLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.Data
{
	public class DataAccess : IDataAccess
	{
		//private List<EmployeeModel> _employees { get; set; }
		private readonly EFCoreDbContext _dbcontext;

		public DataAccess(EFCoreDbContext dbContext)
		{
			_dbcontext = dbContext;	
		}

		public List<EmployeeModel> GetEmployees()
		{

			return _dbcontext.Set<EmployeeModel>().ToList();
		}

		public EmployeeModel AddEmployee(string firstName,string lastName)
		{
			//fetching the list of all employees
			List<EmployeeModel> employeeList = _dbcontext.Set<EmployeeModel>().ToList();

			//creating a new employee object with the details passed
			EmployeeModel newEmployee = new() { FirstName = firstName, LastName = lastName };

			//determining the id of the new employee
			/*if(employeeList.Any())
			{
				newEmployee.Id = employeeList.Max(x => x.Id) + 1;
			}
			else
			{
				newEmployee.Id = 1;
			}*/


			//adding the new employee object in db
			_dbcontext.Add(newEmployee);
			_dbcontext.SaveChanges();

			return newEmployee;
		}

	}
}
