using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    [Table("TEACHER")]
    [Index(nameof(Email), Name = "UQ__TEACHER__161CF724C0E1A66F", IsUnique = true)]
    [Index(nameof(Contact), Name = "UQ__TEACHER__24C6AAD3695B2177", IsUnique = true)]
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        [Key]
        [Column("TEACHER_ID")]
        public int TeacherId { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("DOB", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Column("DEPARTMENT")]
        [StringLength(10)]
        public string Department { get; set; }
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
        [Column("SALARY")]
        public int? Salary { get; set; }

        [InverseProperty(nameof(Class.Teacher))]
        public virtual ICollection<Class> Classes { get; set; }
    }
}
