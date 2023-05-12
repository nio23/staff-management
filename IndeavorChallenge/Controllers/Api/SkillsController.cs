using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.UI.WebControls;
using AutoMapper;
using IndeavorChallenge.Dtos;
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
        public IEnumerable<SkillDto> GetSkills()
        {
            return m_context.Skills.ToList().Select(Mapper.Map<Skill, SkillDto>);
        }

        //GET /api/skill/1
        public SkillDto GetSkill(int id)
        {
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == id);

            if (skill == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Skill, SkillDto>(skill);
        }

        //POST /api/skills
        [HttpPost]
        public SkillDto CreateSkill(SkillDto skillDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var skill = Mapper.Map<SkillDto, Skill>(skillDto);

            m_context.Skills.Add(skill);
            m_context.SaveChanges();

            skillDto.id = skill.id;

            return skillDto;
        }

        //PUT /api/skills/1
        [HttpPut]
        public void UpdateSkill(int id,  SkillDto skillDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var dbSkill = m_context.Skills.SingleOrDefault(x => x.id == id);

            if (dbSkill == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<SkillDto, Skill>(skillDto, dbSkill);

            m_context.SaveChanges();

        }

        //DELETE /api/skills/1
        [HttpDelete]
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
