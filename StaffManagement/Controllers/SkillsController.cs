using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using StaffManagement.Models;

namespace StaffManagement.Controllers
{
    public class SkillsController : Controller
    {
        private ApplicationDbContext m_context;

        public SkillsController()
        {
            m_context = new ApplicationDbContext();
        }


        // GET: Skills
        public ActionResult Index()
        {
            //var skills = m_context.Skills.ToList();


            //return View(skills);
            return View();
        }


        public ActionResult Edit(int id )
        {
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == id);

            if (skill == null)
                return HttpNotFound();

            return View("New", skill);
        }


        public ActionResult New()
        {
            var skill = new Skill();
            return View(skill);
        }

        //Using parameter mvc initialize and binds data
        [HttpPost]
        public ActionResult Save(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View("New", skill);
            }


            if (skill.id == 0)
            {
                m_context.Skills.Add(skill);
            }
            else
            {
                var dbSkill = m_context.Skills.SingleOrDefault(x => x.id == skill.id);

                dbSkill.name = skill.name;
                dbSkill.description = skill.description;
                //dbSkill.dateCreated = skill.dateCreated;

            }


            m_context.SaveChanges();

            return RedirectToAction("Index","Skills");
        }
    }
}