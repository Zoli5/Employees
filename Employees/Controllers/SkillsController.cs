using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employees.Controllers
{
    public class SkillsController : Controller
    {
        private ApplicationDbContext _context;

        public SkillsController()
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