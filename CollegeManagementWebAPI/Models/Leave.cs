using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Leave
    {
        public int LeaveApplicationId { get; set; }
        public string LeaveApplicationReason { get; set; }
        public DateTime LeaveDate { get; set; }
        public int? LeaveDuration { get; set; }
        public int? AppliedBy { get; set; }
        public DateTime AppliedAt { get; set; }
        public bool? IsApproved { get; set; }

        public virtual Login AppliedByNavigation { get; set; }
    }
}
