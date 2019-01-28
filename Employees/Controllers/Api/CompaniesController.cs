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

        // GET: /api/company/id
        public IHttpActionResult GetCompany(int id)
        {
            var companyQuery = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (companyQuery == null)
                return NotFound();

            return Ok(companyQuery);
        }

        [HttpPost]
        public IHttpActionResult CreateCompany(Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Companies.Add(company);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + company.Id), company);
        }

        [HttpPut]
        public IHttpActionResult UpdateCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var companyInDb = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (companyInDb == null)
                return NotFound();

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCompany(int id)
        {
            var companyInDb = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (companyInDb == null)
                return NotFound();

            _context.Companies.Remove(companyInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
