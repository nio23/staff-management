using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndeavorChallenge.Models;

namespace IndeavorChallenge.Controllers
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
            /*var skills = new List<Skill>();
            skills.Add(new Skill(){id = 1, name = "Organize", dateCreated = new DateTime(2018, 5, 22) });
            skills.Add(new Skill(){id = 2, name = "Leadership", dateCreated = new DateTime(2015,2,5)});*/

            var skills = m_context.Skills.ToList();
            

            return View(skills);
        }


        public ActionResult Detail(int id )
        {
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == id);

            return View("Detail",skill);
        }


    }
}