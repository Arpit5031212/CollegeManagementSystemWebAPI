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
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:CollegeDbConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AdminPassword)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.AdminUsername).IsUnicode(false);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ClassName)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__CLASS__TEACHER_I__59063A47");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CourseName).IsUnicode(false);

                entity.Property(e => e.Duration)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.HasKey(e => e.LeaveApplicationId)
                    .HasName("PK__LEAVE__19DAA0AF0287681C");

                entity.Property(e => e.IsApproved).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AppliedByNavigation)
                    .WithMany(p => p.Leaves)
                    .HasForeignKey(d => d.AppliedBy)
                    .HasConstraintName("FK__LEAVE__APPLIED_B__5EBF139D");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.IsVerified).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLogin)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Password)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Token).HasDefaultValueSql("((0))");

                entity.Property(e => e.TokenExpired).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserRole).HasDefaultValueSql("((2))");

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasOne(d => d.PostedByNavigation)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.PostedBy)
                    .HasConstraintName("FK__NOTICE__POSTED_B__5BE2A6F2");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.ClassId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CourseId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__STUDENT__CLASS_I__66603565");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__STUDENT__COURSE___656C112C");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SubjectId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SubjectName).IsUnicode(false);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Department)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
