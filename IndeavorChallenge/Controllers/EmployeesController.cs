using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IndeavorChallenge.Models;

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
            var empl = m_context.Employees.SingleOrDefault(x => x.id == id);
            if (empl == null)
                return HttpNotFound();

            return View("New",empl);
        }

        public ActionResult New()
        {
            var emp = new Employee();

            return View(emp);
        }

        [HttpPost]
        public ActionResult Save(Employee empl)
        {
            if (empl.id == 0)
            {
                m_context.Employees.Add(empl);
            }
            else
            {
                var dbempl = m_context.Employees.SingleOrDefault(x => x.id == empl.id);

                dbempl.name = empl.name;
                dbempl.surname = empl.surname;
                dbempl.hiringDate = empl.hiringDate;
                dbempl.skills = empl.skills;

            }


            m_context.SaveChanges();

            return RedirectToAction("Index", "Skills");
        }
    }
}