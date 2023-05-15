using System;

namespace CollegeManagementWebAPI.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CourseId { get; set; }
        public string ClassId { get; set; }
        public int LoginId { get; set; }

    }
}
