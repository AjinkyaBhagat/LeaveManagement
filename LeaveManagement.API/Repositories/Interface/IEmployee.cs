using LeaveManagement.API.Models.Domain;
using LeaveManagement.API.Models.DTO;

namespace LeaveManagement.API.Repositories.Interface
{
    public interface IEmployee
    {
        Task<Employee> Login(LoginDto loginDto);
        Task<List<Employee>> GetAllAsync();
        Task<Employee> CreateAsync(Employee employee);

        Task<Employee>GetByIdAsync(Guid id);    
        Task<Employee> UpdateAsync(Guid id, Employee employee);
    }
}
