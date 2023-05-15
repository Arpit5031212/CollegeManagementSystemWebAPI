using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("COURSE")]
    [Index(nameof(CourseName), Name = "UQ__COURSE__CD6EAA3F01608361", IsUnique = true)]
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        [Column("COURSE_ID")]
        [StringLength(10)]
        public string CourseId { get; set; }
        [Required]
        [Column("COURSE_NAME")]
        [StringLength(100)]
        public string CourseName { get; set; }
        [Column("DURATION")]
        [StringLength(10)]
        public string Duration { get; set; }

        [InverseProperty(nameof(Student.Course))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
