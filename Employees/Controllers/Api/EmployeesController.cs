using System.Linq;
using System.Web.Http;
using Employees.Models;

namespace Employees.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/companies
        public IHttpActionResult GetEmployees()
        {
            var employeesQuery = _context.Employees;

            return Ok(employeesQuery.ToList());
        }
    }
}
