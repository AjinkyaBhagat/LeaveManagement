using LeaveManagement.API.Models.Domain;

namespace LeaveManagement.API.Repositories.Interface
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> CreateAsync(Employee employee);

        Task<Employee>GetByIdAsync(Guid id);    
    }
}
