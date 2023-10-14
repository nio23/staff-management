using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using StaffManagement.Dtos;
using StaffManagement.Models;

namespace StaffManagement.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Skill, SkillDto>();
            Mapper.CreateMap<SkillDto, Skill>();
            Mapper.CreateMap<Skill, Skill>();
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>();
            Mapper.CreateMap<Employee, Employee>();
        }
    }
}