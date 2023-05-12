using System;
using System.Collections.Generic;
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
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return m_context.Employees.ToList().Select(Mapper.Map<Employee,EmployeeDto>);
        }

        //GET /api/employees/1
        public EmployeeDto GetEmployee(int id)
        {
            var employee = m_context.Employees.SingleOrDefault(x => x.id == id);

            if (employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Employee,EmployeeDto>(employee);
        }

        //POST /api/employees
        [HttpPost]
        public Employee CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);

            m_context.Employees.Add(employee);
            m_context.SaveChanges();

            employeeDto.id = employee.id;

            return employee;
        }

        //PUT /api/employees/1
        [HttpPut]
        public void UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbEmployee = m_context.Employees.SingleOrDefault(x => x.id == id);

            if (dbEmployee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<EmployeeDto, Employee>(employeeDto, dbEmployee);

            m_context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            var employee = m_context.Employees.SingleOrDefault(x => x.id == id);
            if (employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            m_context.Employees.Remove(employee);

            m_context.SaveChanges();
        }
    }
}
