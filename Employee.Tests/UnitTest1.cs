using EmployeeManagement.API.Controllers;
using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Handlers;
using EmployeeManagementLibrary.Models;
using EmployeeManagementLibrary.Queries;
using MediatR;
using Moq;

namespace Employee.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void GetEndpointinController_Returns_ListofEmployees()
        {
            //Arrange - Getting the requirements 
            var mock = new Mock<IMediator>();

            mock.Setup(m => m.Send(It.IsAny<GetEmployeeListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new List<EmployeeModel>
            {
                new EmployeeModel { Id = 1,FirstName="Ben",LastName="Rogers"},
                new EmployeeModel { Id = 2,FirstName="Jacob",LastName="S2"},

            });
            var controller = new EmployeesController(mock.Object);

            //Act 
            var result = await controller.Get();

            //Assert
            var checkReturn = Assert.IsType<List<EmployeeModel>>(result);
            Assert.Equal(2, checkReturn.Count());
            Assert.Equal(1, checkReturn[0].Id);
            Assert.Equal(2, checkReturn[1].Id);

        }

        [Fact]
        public async void GetListQueryHandler_Returns_ListofEmployees()
        {
            //Arrange
            var mock = new Mock<IDataAccess>();
            mock.Setup(m => m.GetEmployees()).Returns(new List<EmployeeModel>
            {                
                new EmployeeModel { Id = 1,FirstName="Ben",LastName="Rogers"},
                new EmployeeModel { Id = 2,FirstName="Jacob",LastName="S2"},
            });

            var handler =new GetEmployeeListHandler(mock.Object);

            //Act
            var result =await handler.Handle(new GetEmployeeListQuery(),CancellationToken.None);

            //Assert

            var checkReturn = Assert.IsType<List<EmployeeModel>>(result);
            Assert.Equal(2, checkReturn.Count());
            Assert.Equal(1, checkReturn[0].Id);
            Assert.Equal(2, checkReturn[1].Id);

        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async void GetByIdHandler_Returns_EmployeeModel(int id)
        {
            var name = "Ben";
            //Arrange
            var mock = new Mock<IDataAccess>();
            mock.Setup(m=> m.GetEmployees()).Returns(new List<EmployeeModel>
            {
                new EmployeeModel { Id = 1,FirstName=name,LastName="Rogers"},
                new EmployeeModel { Id = 2,FirstName="Jacob",LastName="S2"},
            });

            var handler =new GetEmployeeByIdHandler(mock.Object);

            //Act

            var result =await handler.Handle(new GetEmployeeByIdQuery(id),CancellationToken.None);

            //Assert

            var checkReturn = Assert.IsType<EmployeeModel>(result);

            if(id == 3)
            {
                Assert.Equal(0,result.Id);
                Assert.Null(result.FirstName); 
                Assert.Null(result.LastName);
            }
            else
            {
                Assert.NotEqual(0, result.Id);
                Assert.NotNull(result.FirstName);
            }

            if (id == 1)
            {
                Assert.Equal(name, result.FirstName);
            }


        }
    }
}