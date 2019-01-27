using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
    }
}