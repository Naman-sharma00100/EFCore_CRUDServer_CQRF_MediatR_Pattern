using EmployeeManagementLibrary.Commands;
using EmployeeManagementLibrary.Handlers;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class EmployeesController : ControllerBase
	{
		private readonly IMediator mediator;
		public EmployeesController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet]
		public async Task<List<EmployeeModel>> Get()
		{
			return await mediator.Send(new GetEmployeeListQuery());
		}

		[HttpGet("id")]
		public async Task<EmployeeModel> GetbyId(int id)
		{
			return await mediator.Send(new GetEmployeeByIdQuery(id));
		}

		[HttpPost]
		public async Task<EmployeeModel> Add([FromBody]EmployeeModel employeeModel)
		{
			return await mediator.Send(new AddEmployeeCommand(employeeModel.FirstName, employeeModel.LastName));
		}



	}
}
