using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
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
        [HttpGet]
        public IHttpActionResult GetSkills()
        {
            return Ok(m_context.Skills.Select(Mapper.Map<Skill, SkillDto>));
        }

        //GET /api/skills/1
        public IHttpActionResult GetSkill(int id)
        {
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == id);

            if (skill == null)
                return NotFound();

            return Ok(Mapper.Map<Skill, SkillDto>(skill));
        }

        //POST /api/skills
        [HttpPost]
        public IHttpActionResult CreateSkill(SkillDto skillDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var skill = Mapper.Map<SkillDto, Skill>(skillDto);

            m_context.Skills.Add(skill);
            m_context.SaveChanges();

            skillDto.id = skill.id;

            return Created(new Uri(Request.RequestUri + "/"+skill.id), skillDto);
        }

        //PUT /api/skills/1
        [HttpPut]
        public IHttpActionResult UpdateSkill(int id,  SkillDto skillDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbSkill = m_context.Skills.SingleOrDefault(x=>x.id == id);
            if (dbSkill == null)
                return NotFound();

            Mapper.Map<SkillDto, Skill>(skillDto, dbSkill);

            m_context.SaveChanges();
            
            return Ok();

        }

        //DELETE /api/skills/1
        [HttpDelete]
        public IHttpActionResult DeleteSkill(int id)
        {
            var skill = m_context.Skills.SingleOrDefault(x=>x.id == id);

            if (skill == null)
                return NotFound();

            m_context.Skills.Remove(skill);
            m_context.SaveChanges();

            return Ok();
        }

    }
}
