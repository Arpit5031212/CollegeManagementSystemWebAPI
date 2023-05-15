using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("LOGIN")]
    [Index(nameof(Username), Name = "UQ__LOGIN__B15BE12E8B8BF97A", IsUnique = true)]
    public partial class Login
    {
        public Login()
        {
            Leaves = new HashSet<Leave>();
            Notices = new HashSet<Notice>();
        }

        [Key]
        [Column("LOGIN_ID")]
        public int LoginId { get; set; }
        [Required]
        [Column("USERNAME")]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [Column("PASSWORD")]
        [StringLength(128)]
        public string Password { get; set; }
        [Column("IS_VERIFIED")]
        public bool? IsVerified { get; set; }
        [Column("USER_ROLE")]
        public int? UserRole { get; set; }
        [Column("TOKEN")]
        [StringLength(100)]
        public string Token { get; set; }
        [Column("TOKEN_EXPIRED")]
        public bool? TokenExpired { get; set; }
        [Column("CREATED_AT", TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }
        [Column("UPDATED_AT", TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; }
        [Required]
        [Column("LAST_LOGIN")]
        public byte[] LastLogin { get; set; }
        [Column("LAST_IP")]
        [StringLength(100)]
        public string LastIp { get; set; }

        [InverseProperty(nameof(Leave.AppliedByNavigation))]
        public virtual ICollection<Leave> Leaves { get; set; }
        [InverseProperty(nameof(Notice.PostedByNavigation))]
        public virtual ICollection<Notice> Notices { get; set; }
    }
}
