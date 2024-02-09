using LeaveManagement.API.Data;
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
        public Task<List<Models.Domain.Employee>> GetAllAsync()
        {
            return dBContext.Employees.ToListAsync();
        }


        public async Task<Models.Domain.Employee> CreateAsync(Models.Domain.Employee employee)
        {
            await dBContext.AddAsync(employee);
            await dBContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Models.Domain.Employee> GetByIdAsync(Guid id)
        {
           return dBContext.Employees.FirstOrDefault(x=>x.EmployeeId ==id);
        }
    }
}


