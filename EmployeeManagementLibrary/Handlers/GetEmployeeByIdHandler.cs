using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.Handlers
{
	public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery,EmployeeModel>
	{
		private readonly IDataAccess dataAccess;
		public GetEmployeeByIdHandler(IDataAccess dataAccess)
		{
			this.dataAccess = dataAccess;
		}

		public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery query,CancellationToken cancellationToken)
		{
			List<EmployeeModel> employeeList = dataAccess.GetEmployees();
			EmployeeModel employee = employeeList.First(x=>x.Id == query.id);
			if(employee == null)
			{
				employee = new EmployeeModel();
				return await Task.FromResult(employee);
			}
			return await Task.FromResult(employee);
		}
	}
}
