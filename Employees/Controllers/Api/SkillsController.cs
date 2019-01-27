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

        // GET: /api/companies
        public IHttpActionResult GetSkills()
        {
            var skillsQuery = _context.Skills;

            return Ok(skillsQuery.ToList());
        }
    }
}
