using EmployeeManagementLibrary.Commands;
using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLibrary.Handlers
{
	public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand,EmployeeModel>
	{
		private readonly IDataAccess _dataAccess;

		public AddEmployeeHandler(IDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public async Task<EmployeeModel> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
		{
			return await Task.FromResult(_dataAccess.AddEmployee(request.firstName,request.lastName));
		}
	}
}
