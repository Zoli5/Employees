using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Employees.Models;

namespace Employees.ViewModels
{
    public class CompanyFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Address { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Company" : "New Company";
            }
        }

        public CompanyFormViewModel()
        {
            Id = 0;
        }

        public CompanyFormViewModel(Company company)
        {
            Id = company.Id;
            Name = company.Name;
            PhoneNumber = company.PhoneNumber;
            Email = company.Email;
            Address = company.Address;
        }
    }
}