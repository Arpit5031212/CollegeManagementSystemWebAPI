using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public string ClassId { get; set; }
        public string TeacherId { get; set; }
        public string ClassName { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
