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
using IndeavorChallenge.Dtos;

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
            //var employees = m_context.Employees.ToList();
            //return View(employees);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var emplDto = m_context.Employees.Include(c=>c.skills).Select(Mapper.Map<Employee, EmployeeDto>).SingleOrDefault(x => x.id == id);
            //var emplDto = Mapper.Map<Employee, EmployeeDto>(empl);
            var skills = m_context.Skills.Select(Mapper.Map<Skill, SkillDto>);



            if (emplDto == null)
                return HttpNotFound();

            /*var viewModel = new EmployeeViewModel
            {
                employeeDto = emplDto,
                allSkills = skills,
                selectedSkills = emplDto.skills.Select(x => x.id).ToList()
            };*/

            var viewModel = new EmployeeViewModel(emplDto, skills, emplDto.skills.Select(x => x.id).ToList());

            

            return View("EmployeeForm", viewModel);
        }

        public ActionResult New()
        {
            var emp = new EmployeeDto();
            var skills = m_context.Skills.Select(Mapper.Map<Skill, SkillDto>).ToList();

            var viewModel = new EmployeeViewModel
            {
                employeeDto = emp,
                allSkills = skills
            };



            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(EmployeeViewModel viewModel)
        {
            Debug.WriteLine("Try to save");

  
            if (!ModelState.IsValid)
            {
                var vm = new EmployeeViewModel
                {
                    employeeDto = viewModel.employeeDto,
                    allSkills = m_context.Skills.Select(Mapper.Map<Skill, SkillDto>).ToList(),
                    selectedSkills = viewModel.selectedSkills

                };
                return View("EmployeeForm", vm);
            }

            var selectedSkillsId = viewModel.skillCheckBoxes
                .Where(m => m.isChecked)
                .Select(x => x.skill.id);

            var dbSelectedSkills = m_context.Skills
                .Where(x => selectedSkillsId
                .Contains(x.id))
                .Distinct()
                .ToList();

            /*var dbSelectedSkills = m_context.Skills
                .Where(x => viewModel.selectedSkills
                .Contains(x.id))
                .Distinct()
                .ToList();*/
                     
            if (viewModel.employeeDto.id == 0)
            {
                
                var empl = m_context.Employees.Add(Mapper.Map<EmployeeDto, Employee>(viewModel.employeeDto));                
                //selectedSkills.ForEach(x => x.employees.Add(empl));
                Mapper.Map<EmployeeDto, Employee>(viewModel.employeeDto, empl);
                empl.skills = dbSelectedSkills;
            }
            else
            {
                var dbempl = m_context.Employees
                    .Include(x=>x.skills)
                    .Single(x => x.id == viewModel.employeeDto.id);
                Mapper.Map<EmployeeDto, Employee>(viewModel.employeeDto, dbempl);
                dbempl.skills = dbSelectedSkills;

                /*dbempl.name = employee.name;
                dbempl.surname = employee.surname;
                dbempl.hiringDate = employee.hiringDate;
                dbempl.skills = employee.skills;*/


            }


            m_context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

       
    }
}