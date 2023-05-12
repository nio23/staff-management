using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.UI.WebControls;
using IndeavorChallenge.Models;

namespace IndeavorChallenge.Controllers.Api
{
    public class SkillsController : ApiController
    {
        private ApplicationDbContext m_context;

        public SkillsController()
        {
            m_context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            m_context.Dispose();
        }

        //GET /api/skills
        public IEnumerable<Skill> GetSkills()
        {
            return m_context.Skills.ToList();
        }

        //GET /api/skill/1
        public Skill GetSkill(int id)
        {
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == id);

            if (skill == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return skill;
        }

        //POST /api/skills
        [HttpPost]
        public Skill CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            m_context.Skills.Add(skill);
            m_context.SaveChanges();

            return skill;
        }

        //PUT /api/skills/1
        [HttpPut]
        public void UpdateSkill(int id,  Skill skill)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbSkill = m_context.Skills.SingleOrDefault(x => x.id == id);

            if (dbSkill == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbSkill.name = skill.name;
            dbSkill.dateCreated = DateTime.Now;

            m_context.SaveChanges();

        }

        //DELETE /api/skills/1
        public void DeleteSkill(int id)
        {
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == id);

            if (skill == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            m_context.Skills.Remove(skill);
            m_context.SaveChanges();
        }

    }
}
