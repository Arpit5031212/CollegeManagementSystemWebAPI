using System;

namespace CollegeManagementWebAPI.ViewModels
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Department { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? Salary { get; set; }

    }
}
