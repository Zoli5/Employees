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

        // GET: /api/employees
        public IHttpActionResult GetEmployees()
        {
            var employeesQuery = _context.Employees;

            return Ok(employeesQuery.ToList());
        }

        // GET: /api/employee/id
        public IHttpActionResult GetEmployee(int id)
        {
            var employeeQuery = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employeeQuery == null)
                return NotFound();

            return Ok(employeeQuery);
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + employee.Id), employee);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employeeInDb = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employeeInDb == null)
                return NotFound();

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employeeInDb == null)
                return NotFound();

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
