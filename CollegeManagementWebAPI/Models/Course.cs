using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
