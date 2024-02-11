using AutoMapper;
using LeaveManagement.API.Models.Domain;
using LeaveManagement.API.Models.DTO;
using LeaveManagement.API.Repositories.Interface;
using LeaveManagement.API.Repositories.Service;
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
        //Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            var employeeDomain = await employee.Login(loginDto);
            if (employeeDomain == null)
            {
                return NotFound();
            }
            return Ok(employeeDomain);

        }

        //Get All Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            //Get data From Domain Model
            var employeeDomain = await employee.GetAllAsync();
            //mapping DomainModel to Dto
            var employeeDto = mapper.Map<List<EmployeeDto>>(employeeDomain);
            return Ok(employeeDto);
            
        }

        //Get Single Employee By Id
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var employeeDomain = await employee.GetByIdAsync(id);
            if (employeeDomain == null)
            {
                NotFound();
            }
            //Map/Convert Employee Domain Model to Employee DTO.
            return Ok(mapper.Map<EmployeeDto>(employeeDomain));
        }

        //Add Employee to DB
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] AddEmployeeRequestDto addEmployeeRequestDto)
        {
            var employeeDomin = mapper.Map<Employee>(addEmployeeRequestDto);
            employeeDomin = await employee.CreateAsync(employeeDomin);

            var employeeDto = mapper.Map<EmployeeDto>(employeeDomin);
            //return CreatedAtAction(nameof(GetByID), new { id = employeeDto.EmployeeId }, employeeDto);
            return Ok(employeeDto);
        }

        //Update the values
        [HttpPut]
        [Route("Update/Guid:{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeDomain = mapper.Map<Employee>(updateEmployeeDto);
             employeeDomain = await employee.UpdateAsync(id, employeeDomain);
            if (employeeDomain == null)
            {
                return NotFound();
            }
            var employeeDto=mapper.Map<EmployeeDto>(employeeDomain);
            return Ok(employeeDto);
        }
    }
}
