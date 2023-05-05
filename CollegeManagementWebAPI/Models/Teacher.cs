using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public string TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Department { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int? LoginId { get; set; }

        public virtual Login Login { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
