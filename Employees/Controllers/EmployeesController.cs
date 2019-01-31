using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.ViewModels;

namespace Employees.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult New()
        {
            var companies = _context.Companies.ToList();
            var viewModel = new EmployeeFormViewModel()
            {
                Companies = companies
            };

            return View("EmployeeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(c => c.Id == id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel(employee)
            {
                Companies = _context.Companies.ToList()
            };

            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeFormViewModel(employee);

                return View("EmployeeForm", viewModel);
            }

            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                var employeeInDb = _context.Employees.Single(c => c.Id == employee.Id);
                employeeInDb.Name = employee.Name;
                employeeInDb.PhoneNumber = employee.PhoneNumber;
                employeeInDb.Email = employee.Email;
                employeeInDb.Address = employee.Address;
                employeeInDb.Gender = employee.Gender;
                employeeInDb.IdCardNumber = employee.IdCardNumber;
                employeeInDb.Dob = employee.Dob;
                employeeInDb.CompanyId = employee.CompanyId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }
    }
}