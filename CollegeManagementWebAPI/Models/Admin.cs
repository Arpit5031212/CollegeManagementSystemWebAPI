using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Admin
    {
        public string AdminId { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
    }
}
