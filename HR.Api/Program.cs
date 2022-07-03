using HR.Api;
using HR.Api.DataAccess.Entities;
using HR.Api.Models;
using HR.Api.Services;
using HR.DataAccess;
using HR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDb")));
builder.Services.AddScoped<IGenericCRUDService<EmployeeModel>, EmployeeCRUDService>();
builder.Services.AddScoped<IGenericCRUDService<AddressModel>, AddressCRUDService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IGenericRepository<Address>, AddressRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
