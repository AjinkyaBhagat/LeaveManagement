using LeaveManagement.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.API.Data
{
    public class LeaveManagementDBContext : DbContext
    {
        public LeaveManagementDBContext(DbContextOptions options):base (options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
    }
}
