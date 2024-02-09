using AutoMapper;
using LeaveManagement.API.Models.Domain;
using LeaveManagement.API.Models.DTO;

namespace LeaveManagement.API.Mappings
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
