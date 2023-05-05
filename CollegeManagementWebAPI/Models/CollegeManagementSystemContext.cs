using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CollegeManagementWebAPI.Models
{
    public partial class CollegeManagementSystemContext : DbContext
    {
        public CollegeManagementSystemContext()
        {
        }

        public CollegeManagementSystemContext(DbContextOptions<CollegeManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=CollegeDbConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("ADMIN");

                entity.HasIndex(e => e.AdminUsername, "UQ__ADMIN__B8B5979BFBA8881A")
                    .IsUnique();

                entity.Property(e => e.AdminId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_PASSWORD")
                    .IsFixedLength(true);

                entity.Property(e => e.AdminUsername)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_USERNAME");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("CLASS");

                entity.HasIndex(e => e.ClassName, "UQ__CLASS__56276132590B46AA")
                    .IsUnique();

                entity.Property(e => e.ClassId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.ClassName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_NAME")
                    .IsFixedLength(true);

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TEACHER_ID")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__CLASS__TEACHER_I__59063A47");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.HasIndex(e => e.CourseName, "UQ__COURSE__CD6EAA3F01608361")
                    .IsUnique();

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_NAME");

                entity.Property(e => e.Duration)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DURATION")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.HasKey(e => e.LeaveApplicationId)
                    .HasName("PK__LEAVE__19DAA0AF0287681C");

                entity.ToTable("LEAVE");

                entity.Property(e => e.LeaveApplicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("LEAVE_APPLICATION_ID");

                entity.Property(e => e.AppliedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("APPLIED_AT");

                entity.Property(e => e.AppliedBy).HasColumnName("APPLIED_BY");

                entity.Property(e => e.IsApproved)
                    .HasColumnName("IS_APPROVED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaveApplicationReason)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("LEAVE_APPLICATION_REASON");

                entity.Property(e => e.LeaveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LEAVE_DATE");

                entity.Property(e => e.LeaveDuration).HasColumnName("LEAVE_DURATION");

                entity.HasOne(d => d.AppliedByNavigation)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.AppliedBy)
                    .HasConstraintName("FK__LEAVE__APPLIED_B__5EBF139D");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.HasIndex(e => e.Username, "UQ__LOGIN__B15BE12E8B8BF97A")
                    .IsUnique();

                entity.Property(e => e.LoginId)
                    .ValueGeneratedNever()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.IsVerified)
                    .HasColumnName("IS_VERIFIED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastIp)
                    .HasMaxLength(100)
                    .HasColumnName("LAST_IP");

                entity.Property(e => e.LastLogin)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("LAST_LOGIN");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD")
                    .IsFixedLength(true);

                entity.Property(e => e.Token)
                    .HasMaxLength(100)
                    .HasColumnName("TOKEN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TokenExpired)
                    .HasColumnName("TOKEN_EXPIRED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_AT");

                entity.Property(e => e.UserRole)
                    .HasColumnName("USER_ROLE")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.ToTable("NOTICE");

                entity.Property(e => e.NoticeId)
                    .ValueGeneratedNever()
                    .HasColumnName("NOTICE_ID");

                entity.Property(e => e.NoticeText)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("NOTICE_TEXT");

                entity.Property(e => e.PostedBy).HasColumnName("POSTED_BY");

                entity.Property(e => e.PostedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("POSTED_ON");

                entity.HasOne(d => d.PostedByNavigation)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.PostedBy)
                    .HasConstraintName("FK__NOTICE__POSTED_B__5BE2A6F2");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.HasIndex(e => e.Email, "UQ__STUDENT__161CF724F6DB1F9B")
                    .IsUnique();

                entity.HasIndex(e => e.Contact, "UQ__STUDENT__24C6AAD33884ECB1")
                    .IsUnique();

                entity.HasIndex(e => e.RollNo, "UQ__STUDENT__7525F925F39054C5")
                    .IsUnique();

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("STUDENT_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLASS");

                entity.Property(e => e.ClassId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLASS_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Contact).HasColumnName("CONTACT");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COURSE_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.LoginId).HasColumnName("LOGIN_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME")
                    .IsFixedLength(true);

                entity.Property(e => e.RollNo).HasColumnName("ROLL_NO");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__STUDENT__CLASS_I__66603565");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__STUDENT__COURSE___656C112C");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__STUDENT__LOGIN_I__6754599E");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("SUBJECT");

                entity.HasIndex(e => e.SubjectName, "UQ__SUBJECT__29B3CFA791A5E094")
                    .IsUnique();

                entity.HasIndex(e => e.SubjectId, "UQ__SUBJECT__EF51E561F51F91C8")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT_NAME");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("TEACHER");

                entity.HasIndex(e => e.Email, "UQ__TEACHER__161CF724C0E1A66F")
                    .IsUnique();

                entity.HasIndex(e => e.Contact, "UQ__TEACHER__24C6AAD3695B2177")
                    .IsUnique();

                entity.Property(e => e.TeacherId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TEACHER_ID")
                    .IsFixedLength(true);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Contact).HasColumnName("CONTACT");

                entity.Property(e => e.Department)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT")
                    .IsFixedLength(true);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.LoginId).HasColumnName("LOGIN_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Salary).HasColumnName("SALARY");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FK__TEACHER__LOGIN_I__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
