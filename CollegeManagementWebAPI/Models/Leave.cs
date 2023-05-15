using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("LEAVE")]
    public partial class Leave
    {
        [Key]
        [Column("LEAVE_APPLICATION_ID")]
        public int LeaveApplicationId { get; set; }
        [Required]
        [Column("LEAVE_APPLICATION_REASON", TypeName = "text")]
        public string LeaveApplicationReason { get; set; }
        [Column("LEAVE_DATE", TypeName = "datetime")]
        public DateTime LeaveDate { get; set; }
        [Column("LEAVE_DURATION")]
        public int? LeaveDuration { get; set; }
        [Column("APPLIED_BY")]
        public int? AppliedBy { get; set; }
        [Column("APPLIED_AT", TypeName = "datetime")]
        public DateTime AppliedAt { get; set; }
        [Column("IS_APPROVED")]
        public bool? IsApproved { get; set; }

        [ForeignKey(nameof(AppliedBy))]
        [InverseProperty(nameof(Login.Leaves))]
        public virtual Login AppliedByNavigation { get; set; }
    }
}
