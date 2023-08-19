using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IndeavorChallenge.Dtos;
using IndeavorChallenge.Models;

namespace IndeavorChallenge.Controllers.Api
{
    
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext m_context;

        public EmployeesController()
        {
            m_context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //GET /api/employees
        public IHttpActionResult GetEmployees()
        {
            return Ok( m_context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDto>));
        }

        //GET /api/employees/1
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = m_context.Employees.Include(x=>x.skills).SingleOrDefault(x => x.id == id);

            if (employee == null)
                return NotFound();

            return Ok(Mapper.Map<Employee,EmployeeDto>(employee));
        }

        //POST /api/employees
        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);

            m_context.Employees.Add(employee);
            m_context.SaveChanges();

            employeeDto.id = employee.id;

            return Created(new Uri(Request.RequestUri + "/" + employee.id), employeeDto);
        }

        //PUT /api/employees/1
        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbEmployee = m_context.Employees.Include(x=> x.skills).SingleOrDefault(x => x.id == id);
            

            if (dbEmployee == null)
                return NotFound();


            Mapper.Map<EmployeeDto, Employee>(employeeDto, dbEmployee);

            m_context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = m_context.Employees.SingleOrDefault(x => x.id == id);
            if (employee == null)
                return NotFound();
            m_context.Employees.Remove(employee);

            m_context.SaveChanges();
            return Ok();
        }

        //DELETE /api/employees/employeeSkill/1

        [Route("api/employees/employeeSkill/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteEmployeeSkill(int id)
        {
            return Ok();
        }

        [Route("api/employees/employeeSkill/{id}")]
        [HttpPut]
        public IHttpActionResult AddEmployeeSkill(int emplId, int skillId)
        {
            var empl = m_context.Employees.Include(x=>x.skills).SingleOrDefault(x => x.id == emplId);
            var skill = m_context.Skills.Single(x=>x.id == skillId);

            //empl.skills.Where(x => x.id != skillId);
            empl.skills.Add(skill);

            return Ok();

        }

        /*[HttpPut]
        public IHttpActionResult DeleteSkill(int employeeId, int skillId)
        {
            var empl = m_context.Employees.Include(x=>x.skills).SingleOrDefault(x => x.id == employeeId);
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == skillId);

            if (empl == null || skill == null)
                return NotFound();
            empl.skills.Remove(skill);

            m_context.SaveChanges();
            return Ok();
        }*/

    }
}
