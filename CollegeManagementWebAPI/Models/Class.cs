using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("CLASS")]
    [Index(nameof(ClassName), Name = "UQ__CLASS__56276132590B46AA", IsUnique = true)]
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        [Column("CLASS_ID")]
        [StringLength(10)]
        public string ClassId { get; set; }
        [Column("TEACHER_ID")]
        public int? TeacherId { get; set; }
        [Column("CLASS_NAME")]
        [StringLength(10)]
        public string ClassName { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Classes")]
        public virtual Teacher Teacher { get; set; }
        [InverseProperty(nameof(Student.Class))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
