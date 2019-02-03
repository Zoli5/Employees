using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.ViewModels;

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

        public ActionResult New()
        {
            var employees = _context.Employees.ToList();
            var viewModel = new SkillFormViewModel()
            {
                Employees = employees
            };

            return View("SkillForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var skill = _context.Skills.SingleOrDefault(s => s.Id == id);

            if (skill == null)
                return HttpNotFound();

            var viewModel = new SkillFormViewModel(skill)
            {
                Employees = _context.Employees.ToList()
            };

            return View("SkillForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Skill skill)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new SkillFormViewModel(skill);

                return View("SkillForm", viewModel);
            }

            if (skill.Id == 0)
            {
                _context.Skills.Add(skill);
            }
            else
            {
                var skillInDb = _context.Skills.Single(s => s.Id == skill.Id);
                skillInDb.Description = skill.Description;
                skillInDb.EmployeeId = skill.EmployeeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Skills");
        }
    }
}