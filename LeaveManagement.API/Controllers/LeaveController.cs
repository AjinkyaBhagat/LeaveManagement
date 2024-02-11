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
    public class LeaveController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILeave leave;

        public LeaveController(IMapper mapper, ILeave leave)
        {
            this.mapper = mapper;
            this.leave = leave;
        }

        //Get All Leaves
        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            //Get data From Domain Model
            var leaveDomain = await leave.GetAllAsync();
            //mapping DomainModel to Dto
            var leaveDto = mapper.Map<List<LeaveDto>>(leaveDomain);
            return Ok(leaveDto);
        }

        //Get Employee Leaves By Id
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var leaveDomain = await leave.GetByIdAsync(id);

            if (leaveDomain == null)
            {
                // Return a NotFound response.
                return NotFound();
            }

            // Map/Convert Leave Domain Model to Leave DTO.
           // return Ok(mapper.Map<LeaveDto>(leaveDomain));
           return Ok(leaveDomain);
        }

        //Add Leave to DB
        [HttpPost]
        [Route("ApplyForLeave")]
        public async Task<IActionResult> ApplyForLeave([FromBody] AddLeaveRequestDto addLeaveRequestDto)
        {
            var leaveDomin = mapper.Map<Leave>(addLeaveRequestDto);
            leaveDomin = await leave.CreateAsync(leaveDomin);

            var leaveDto = mapper.Map<LeaveDto>(leaveDomin);

            return CreatedAtAction(nameof(GetByID), new { id = leaveDto.LeaveId }, leaveDto);
        }
    }
}

