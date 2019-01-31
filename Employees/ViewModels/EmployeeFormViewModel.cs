using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Employees.Models;

namespace Employees.ViewModels
{
    public class EmployeeFormViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Address { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Identity Card Number")]
        public string IdCardNumber { get; set; }

        public Company Company { get; set; }
        [Display(Name = "Company")]
        public int? CompanyId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Employee" : "New Employee";
            }
        }

        public EmployeeFormViewModel()
        {
            Id = 0;
        }

        public EmployeeFormViewModel(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            PhoneNumber = employee.PhoneNumber;
            Email = employee.Email;
            Address = employee.Address;
            Gender = employee.Gender;
            Dob = employee.Dob;
            IdCardNumber = employee.IdCardNumber;
            CompanyId = employee.CompanyId;
        }
    }
}