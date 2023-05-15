using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("NOTICE")]
    public partial class Notice
    {
        [Key]
        [Column("NOTICE_ID")]
        public int NoticeId { get; set; }
        [Required]
        [Column("NOTICE_TEXT", TypeName = "text")]
        public string NoticeText { get; set; }
        [Column("POSTED_ON", TypeName = "datetime")]
        public DateTime PostedOn { get; set; }
        [Column("POSTED_BY")]
        public int? PostedBy { get; set; }

        [ForeignKey(nameof(PostedBy))]
        [InverseProperty(nameof(Login.Notices))]
        public virtual Login PostedByNavigation { get; set; }
    }
}
