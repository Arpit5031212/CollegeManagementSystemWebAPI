using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("STUDENT")]
    [Index(nameof(Email), Name = "UQ__STUDENT__161CF724F6DB1F9B", IsUnique = true)]
    [Index(nameof(Contact), Name = "UQ__STUDENT__24C6AAD33884ECB1", IsUnique = true)]
    [Index(nameof(RollNo), Name = "UQ__STUDENT__7525F925F39054C5", IsUnique = true)]
    public partial class Student
    {
        [Key]
        [Column("STUDENT_ID")]
        public int StudentId { get; set; }
        [Column("ROLL_NO")]
        public int RollNo { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("DOB", TypeName = "datetime")]
        public DateTime Dob { get; set; }
        [Required]
        [Column("CONTACT")]
        [StringLength(50)]
        public string Contact { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("ADDRESS", TypeName = "text")]
        public string Address { get; set; }
        [Column("COURSE_ID")]
        [StringLength(10)]
        public string CourseId { get; set; }
        [Column("CLASS_ID")]
        [StringLength(10)]
        public string ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty("Students")]
        public virtual Class Class { get; set; }
        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Students")]
        public virtual Course Course { get; set; }
    }
}
