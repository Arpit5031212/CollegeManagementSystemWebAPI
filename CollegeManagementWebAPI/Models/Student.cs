using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public DateTime Dob { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CourseId { get; set; }
        public string ClassId { get; set; }
        public int? LoginId { get; set; }

        public virtual Class ClassNavigation { get; set; }
        public virtual Course Course { get; set; }
        public virtual Login Login { get; set; }
    }
}
