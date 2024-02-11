using LeaveManagement.API.Data;
using LeaveManagement.API.Models.Domain;
using LeaveManagement.API.Models.DTO;
using LeaveManagement.API.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.API.Repositories.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly LeaveManagementDBContext dBContext;


        public EmployeeService(LeaveManagementDBContext dBContext)
        {
            this.dBContext = dBContext;

        }
        public async Task<List<Models.Domain.Employee>> GetAllAsync()
        {
            return await dBContext.Employees.ToListAsync();
        }


        public async Task<Models.Domain.Employee> CreateAsync(Models.Domain.Employee employee)
        {
            await dBContext.Employees.AddAsync(employee);
            await dBContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Models.Domain.Employee> GetByIdAsync(Guid id)
        {
           return await dBContext.Employees.FirstOrDefaultAsync(x=>x.EmployeeId ==id);
        }

        public async Task<Employee> Login(LoginDto loginDto)
        {
            return await dBContext.Employees.FirstOrDefaultAsync(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
        }

        public async Task<Employee> UpdateAsync(Guid id, Employee employee)
        {
            var existingEmployee = await dBContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.LeavesAvailable= employee.LeavesAvailable;
            await dBContext.SaveChangesAsync();
            return existingEmployee;

        }
    }
}


