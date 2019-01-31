using Employees.Models;
using Employees.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Employees.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext _context;

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Details(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            return View(company);
        }

        public ActionResult New()
        {
            var viewModel = new CompanyFormViewModel();

            return View("CompanyForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
                return HttpNotFound();

            var viewModel = new CompanyFormViewModel(company);

            return View("CompanyForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Company company)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CompanyFormViewModel(company);

                return View("CompanyForm", viewModel);
            }

            if (company.Id == 0)
            {
                _context.Companies.Add(company);
            }
            else
            {
                var companyInDb = _context.Companies.Single(c => c.Id == company.Id);
                companyInDb.Name = company.Name;
                companyInDb.PhoneNumber = company.PhoneNumber;
                companyInDb.Email = company.Email;
                companyInDb.Address = company.Address;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Companies");
        }
    }
}