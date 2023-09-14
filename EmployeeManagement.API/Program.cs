using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataAccess, DataAccess>();
//builder.Services.AddMediatR(typeof(GetEmployeeListHandler).Assembly);
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DataAccess).Assembly));

builder.Services.AddDbContext<EFCoreDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
/*	endpoints.MapControllerRoute(
		name: "employees",
		pattern: "employees/{action=Index}/{id?}",
		defaults: new { controller = "Employees" });*/
});

app.Run();
