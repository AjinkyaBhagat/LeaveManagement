﻿using AutoMapper;
using LeaveManagement.API.Models.Domain;
using LeaveManagement.API.Models.DTO;

namespace LeaveManagement.API.Mappings
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<AddEmployeeRequestDto, Employee>().ReverseMap();
            CreateMap<Leave, LeaveDto>().ReverseMap();
            CreateMap<AddLeaveRequestDto, Leave>().ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();


        }
    }
}
