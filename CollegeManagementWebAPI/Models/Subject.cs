using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("SUBJECT")]
    [Index(nameof(SubjectName), Name = "UQ__SUBJECT__29B3CFA791A5E094", IsUnique = true)]
    [Index(nameof(SubjectId), Name = "UQ__SUBJECT__EF51E561F51F91C8", IsUnique = true)]
    public partial class Subject
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("SUBJECT_NAME")]
        [StringLength(50)]
        public string SubjectName { get; set; }
        [Required]
        [Column("SUBJECT_ID")]
        [StringLength(5)]
        public string SubjectId { get; set; }
    }
}
