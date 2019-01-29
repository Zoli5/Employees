using System;
using System.Data.Entity;
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

            return Ok(employeesQuery.Include(e => e.Company).ToList());
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

            employeeInDb.Address = string.IsNullOrEmpty(employee.Address) ? employeeInDb.Address : employee.Address;
            employeeInDb.CompanyId = string.IsNullOrEmpty(employee.CompanyId.ToString()) ? employeeInDb.CompanyId : employee.CompanyId;
            employeeInDb.Dob = string.IsNullOrEmpty(employee.Dob.ToString()) ? employeeInDb.Dob : employee.Dob;
            employeeInDb.Email = string.IsNullOrEmpty(employee.Email) ? employeeInDb.Email : employee.Email;
            employeeInDb.Gender = string.IsNullOrEmpty(employee.Gender) ? employeeInDb.Gender : employee.Gender;
            employeeInDb.IdCardNumber = string.IsNullOrEmpty(employee.IdCardNumber) ? employeeInDb.IdCardNumber : employee.IdCardNumber;
            employeeInDb.PhoneNumber = string.IsNullOrEmpty(employee.PhoneNumber) ? employeeInDb.PhoneNumber : employee.PhoneNumber;
            employeeInDb.Name = string.IsNullOrEmpty(employee.Name) ? employeeInDb.Name : employee.Name;

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
