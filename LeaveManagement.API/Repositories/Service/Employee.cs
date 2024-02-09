using LeaveManagement.API.Data;
using LeaveManagement.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.API.Repositories.Service
{
    public class Employee : IEmployee
    {
        private readonly LeaveManagementDBContext dBContext;

        public Employee(LeaveManagementDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public Task<List<Models.Domain.Employee>> GetAllAsync()
        {
           return dBContext.Employees.ToListAsync();
        }
    }
}

