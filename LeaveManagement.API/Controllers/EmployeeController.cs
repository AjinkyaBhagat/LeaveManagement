using AutoMapper;
using LeaveManagement.API.Models.Domain;
using LeaveManagement.API.Models.DTO;
using LeaveManagement.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        private readonly IMapper mapper;

        public EmployeeController(IEmployee employee,IMapper mapper)
        {
            this.employee = employee;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            //Get data From Domain Model
            var employeeDomain = await employee.GetAllAsync();
            //mapping DomainModel to Dto
            var employeeDto = mapper.Map<List<EmployeeDto>>(employeeDomain);
            return Ok(employeeDto);
            
        }
    }
}
