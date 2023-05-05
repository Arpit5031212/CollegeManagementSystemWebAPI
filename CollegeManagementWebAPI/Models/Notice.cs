using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class Notice
    {
        public int NoticeId { get; set; }
        public string NoticeText { get; set; }
        public DateTime PostedOn { get; set; }
        public int? PostedBy { get; set; }

        public virtual Login PostedByNavigation { get; set; }
    }
}
