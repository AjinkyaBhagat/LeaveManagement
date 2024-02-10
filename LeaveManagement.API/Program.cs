using LeaveManagement.API.Data;
using LeaveManagement.API.Mappings;
using LeaveManagement.API.Repositories.Interface;
using LeaveManagement.API.Repositories.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject Db Context
builder.Services.AddDbContext<LeaveManagementDBContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("LeaveManagementConnectionString")));

//Dependancy Injection
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<ILeave, LeaveService>();

//AutoMapper Injection
builder.Services.AddAutoMapper(typeof(AutomapperProfiles));


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
