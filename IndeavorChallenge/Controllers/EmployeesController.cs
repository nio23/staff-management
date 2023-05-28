using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IndeavorChallenge.Models;
using IndeavorChallenge.ViewModels;

namespace IndeavorChallenge.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext m_context;

        public EmployeesController()
        {
            m_context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var employees = m_context.Employees.ToList();
            return View(employees);
        }

        public ActionResult Edit(int id)
        {
            var empl = m_context.Employees.Include(c=>c.skills).SingleOrDefault(x => x.id == id);
            var skills = m_context.Skills.ToList();

            if (empl == null)
                return HttpNotFound();

            var viewModel = new EmployeeViewModel
            {
                employee = empl,
                skills = skills

            };
            

            return View("New", viewModel);
        }

        public ActionResult New()
        {
            var emp = new Employee();
            var skills = m_context.Skills.ToList();

            var viewModel = new EmployeeViewModel
            {
                employee = emp,
                skills = skills
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            Debug.WriteLine("Try to save");
            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeViewModel
                {
                    employee = employee,
                    skills = m_context.Skills.ToList()

                };
                Debug.WriteLine("IS INVALID");
                return View("New", viewModel);
            }

            if (employee.id == 0)
            {
                m_context.Employees.Add(employee);
            }
            else
            {
                var dbempl = m_context.Employees.Include(x=>x.skills).SingleOrDefault(x => x.id == employee.id);

                dbempl.name = employee.name;
                dbempl.surname = employee.surname;
                dbempl.hiringDate = employee.hiringDate;
                dbempl.skills = employee.skills;

            }


            m_context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }
    }
}