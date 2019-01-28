using System;
using System.Linq;
using System.Web.Http;
using Employees.Models;

namespace Employees.Controllers.Api
{
    public class SkillsController : ApiController
    {
        private ApplicationDbContext _context;

        public SkillsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/skills
        public IHttpActionResult GetSkills()
        {
            var skillsQuery = _context.Skills;

            return Ok(skillsQuery.ToList());
        }

        // GET: /api/skill/id
        public IHttpActionResult GetSkill(int id)
        {
            var skillQuery = _context.Skills.SingleOrDefault(c => c.Id == id);

            if (skillQuery == null)
                return NotFound();

            return Ok(skillQuery);
        }

        [HttpPost]
        public IHttpActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + skill.Id), skill);
        }

        [HttpPut]
        public IHttpActionResult UpdateSkill(int id, Skill skill)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var skillInDb = _context.Skills.SingleOrDefault(c => c.Id == id);

            if (skillInDb == null)
                return NotFound();

            skillInDb.Description = string.IsNullOrEmpty(skill.Description) ? skillInDb.Description : skill.Description;
            skillInDb.EmployeeId = string.IsNullOrEmpty(skill.EmployeeId.ToString()) ? skillInDb.EmployeeId : skill.EmployeeId;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteSkill(int id)
        {
            var skillInDb = _context.Skills.SingleOrDefault(c => c.Id == id);

            if (skillInDb == null)
                return NotFound();

            _context.Skills.Remove(skillInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
