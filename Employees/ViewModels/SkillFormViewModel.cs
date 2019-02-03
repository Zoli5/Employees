using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Employees.Models;

namespace Employees.ViewModels
{
    public class SkillFormViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public int Id { get; set; }

        public string Description { get; set; }

        public Employee Employee { get; set; }
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Skill" : "New Skill";
            }
        }

        public SkillFormViewModel()
        {
            Id = 0;
        }

        public SkillFormViewModel(Skill skill)
        {
            Id = skill.Id;
            Description = skill.Description;
            EmployeeId = skill.EmployeeId;
        }
    }
}