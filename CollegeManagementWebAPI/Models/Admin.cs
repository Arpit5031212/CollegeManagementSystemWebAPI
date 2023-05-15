using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("ADMIN")]
    [Index(nameof(AdminUsername), Name = "UQ__ADMIN__B8B5979BFBA8881A", IsUnique = true)]
    public partial class Admin
    {
        [Key]
        [Column("ADMIN_ID")]
        [StringLength(10)]
        public string AdminId { get; set; }
        [Required]
        [Column("ADMIN_USERNAME")]
        [StringLength(15)]
        public string AdminUsername { get; set; }
        [Required]
        [Column("ADMIN_PASSWORD")]
        [StringLength(128)]
        public string AdminPassword { get; set; }
    }
}
