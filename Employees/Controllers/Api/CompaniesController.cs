using System.Linq;
using System.Web.Http;
using Employees.Models;

namespace Employees.Controllers.Api
{
    public class CompaniesController : ApiController
    {
        private ApplicationDbContext _context;

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/companies
        public IHttpActionResult GetCompanies()
        {
            var companiesQuery = _context.Companies;

            return Ok(companiesQuery.ToList());
        }
    }
}
