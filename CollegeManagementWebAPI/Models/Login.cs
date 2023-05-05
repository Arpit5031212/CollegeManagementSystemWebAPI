using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Login
    {
        public Login()
        {
            Leaves = new HashSet<Leave>();
            Notices = new HashSet<Notice>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsVerified { get; set; }
        public int? UserRole { get; set; }
        public string Token { get; set; }
        public bool? TokenExpired { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte[] LastLogin { get; set; }
        public string LastIp { get; set; }

        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
