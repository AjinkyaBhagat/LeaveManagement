using LeaveManagement.API.Data;
using LeaveManagement.API.Models.Domain;
using LeaveManagement.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.API.Repositories.Service
{
    public class LeaveService:ILeave
    {
        private readonly LeaveManagementDBContext dBContext;

        public LeaveService(LeaveManagementDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<Leave>> GetAllAsync()
        {
            return await dBContext.Leaves.ToListAsync();
        }

        public async Task<Leave> CreateAsync(Leave leave)
        {
            await dBContext.Leaves.AddAsync(leave);
            await dBContext.SaveChangesAsync();
            return leave;
        }

        public async Task<Leave> GetByIdAsync(Guid id)
        {
            return await dBContext.Leaves.FirstOrDefaultAsync(x => x.EmployeeId == id);
        }
    }
}
