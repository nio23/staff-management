using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult Save(EmployeeViewModel emplViewModel)
        {
            if (emplViewModel.employee.id == 0)
            {
                m_context.Employees.Add(emplViewModel.employee);
            }
            else
            {
                var dbempl = m_context.Employees.SingleOrDefault(x => x.id == emplViewModel.employee.id);

                dbempl.name = emplViewModel.employee.name;
                dbempl.surname = emplViewModel.employee.surname;
                dbempl.hiringDate = emplViewModel.employee.hiringDate;
                dbempl.skills = emplViewModel.employee.skills;

            }


            m_context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }
    }
}