using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<Employee> GetEmployees()
        {
            return m_context.Employees.ToList();
        }

        //GET /api/employees/1
        public Employee GetEmployee(int id)
        {
            var employee = m_context.Employees.SingleOrDefault(x => x.id == id);

            if (employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return employee;
        }

        //POST /api/employees
        [HttpPost]
        public Employee CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            m_context.Employees.Add(employee);
            m_context.SaveChanges();

            return employee;
        }

        //PUT /api/employees/1
        [HttpPut]
        public void UpdateEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbEmployee = m_context.Employees.SingleOrDefault(x => x.id == id);

            if (dbEmployee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbEmployee.name = employee.name;
            dbEmployee.skills = employee.skills;
            dbEmployee.hiringDate = employee.hiringDate;
            dbEmployee.surname = employee.surname;

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
