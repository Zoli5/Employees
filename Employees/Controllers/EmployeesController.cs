using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}