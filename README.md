# EmployeeManagementDemo

### <b> Project Structure</b>:

<b>API Project (EmployeeManagement.API)</b>: This project seems to be responsible for handling HTTP requests and responses. It acts as the entry point for the application.

- <b>Controller (EmployeesController) </b>: The EmployeesController receives HTTP requests and sends corresponding commands or queries to the Mediator for processing. It then handles the response returned by the Mediator.

<b>Library Project (EmployeeManagementLibrary)</b>: This project appears to contain the business logic, data access code, and handlers.

- <b>DataAccess</b>: Contains code for interacting with the database.

- <b>Handlers</b>: Contains classes that handle commands and queries.

- <b>Models</b>: Contains classes that represent the data entities (e.g., EmployeeModel).

- <b>Queries and Commands</b>: Represent the messages that are passed to the Mediator.

- <b>DbContext</b>: Represents the database context for Entity Framework Core.

- <b>ApplicationDbContext</b>: Derives from DbContext and represents the specific context for your application.
