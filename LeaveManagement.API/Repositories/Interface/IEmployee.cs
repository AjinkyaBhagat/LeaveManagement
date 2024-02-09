using LeaveManagement.API.Models.Domain;

namespace LeaveManagement.API.Repositories.Interface
{
    public interface IEmployee
    {
        Task<List<Employee>> GetAllAsync();
    }
}
