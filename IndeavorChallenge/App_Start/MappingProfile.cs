using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IndeavorChallenge.Dtos;
using IndeavorChallenge.Models;

namespace IndeavorChallenge.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Skill, SkillDto>();
            Mapper.CreateMap<SkillDto, Skill>();
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>();
        }
    }
}