using AutoMapper;
using CollegeManagementWebAPI.Models;
using CollegeManagementWebAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollegeManagementWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CollegeManagementSystemContext db;
        private readonly IMapper _mapper;
        public UserRepository(CollegeManagementSystemContext _dbContext, IMapper mapper) 
        {
            db = _dbContext;
            _mapper = mapper;
        }
        public async Task<Student> AddStudentAsync(StudentViewModel student)
        {

            var new_login = new Login()
            {
                Username = student.Email,
                Password = student.Name,
                IsVerified = true,
                UserRole = 2,
                Token = null,
                TokenExpired = false,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
                LastLogin = null,
                LastIp = null,
            };

            db.Logins.Add(new_login);
            await db.SaveChangesAsync();

            var new_student = new Student()
            {
                Name = student.Name,
                RollNo = student.RollNo,
                ClassId = student.ClassId,
                Dob = student.Dob,
                Contact = student.Contact,
                Email = student.Email,
                Address = student.Address,
                CourseId = student.CourseId,
            };

            db.Students.Add(new_student);
            await db.SaveChangesAsync();

            return new_student;
        }

        public async Task<Teacher> AddTeacherAsync(TeacherViewModel teacher)
        {
            var new_login = new Login()
            {
                Username = teacher.Email,
                Password = teacher.Name,
                IsVerified = true,
                UserRole = 1,
                Token = null,
                TokenExpired = false,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
                LastLogin = null,
                LastIp = null,
            };

            db.Logins.Add(new_login);
            await db.SaveChangesAsync();

            var new_teacher = new Teacher()

            {
                Name = teacher.Name,
                Dob = teacher.Dob,
                Department = teacher.Department,
                Contact = teacher.Contact,
                Email = teacher.Email,
                Address = teacher.Address,
                Salary = teacher.Salary,
            };
            db.Teachers.Add(new_teacher);

            await db.SaveChangesAsync();

            return new_teacher;
        }

        public async Task DeleteStudentAsync(int roll)
        {
            var student = new Student() { RollNo = roll };
            db.Students.Remove(student);
            await db.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int teacher_id)
        {
            var teacher = new Teacher() { TeacherId = teacher_id };
            db.Teachers.Remove(teacher);
            await db.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            if(db != null)
            {
                var records = await db.Students.ToListAsync();
                return _mapper.Map<List<Student>>(records);
            }
            return null;
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            if(db != null)
            {
                var records = await db.Teachers.ToListAsync();
                return _mapper.Map<List<Teacher>>(records);
            }
            return null;
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            if(db != null)
            {
                var record = await db.Students.FirstOrDefaultAsync(student => student.Email == email);
                return record;
            }
            return null;
            
        }

        public async Task<List<Student>> GetStudentsByNameAsync(string name)
        {
            if(db != null)
            {
                var students = await db.Students.Where(student => student.Name == name).ToListAsync();
                return _mapper.Map<List<Student>>(students);
            }
            return null;
        }

        public async Task<Student> GetStudentByRollAsync(int roll)
        {
            if (db != null)
            {
                var student = await db.Students.FirstOrDefaultAsync(student => student.RollNo == roll);
                return student;
            }
            return null;
        }

        public async Task<List<Student>> GetStudentsByClassAsync(string _class)
        {
            if(db != null)
            {
                var students = await db.Students.Where(student => student.ClassId == _class).ToListAsync();
                return _mapper.Map<List<Student>>(students);
            }
            return null;
        }

        public async Task<List<Student>> GetStudentsByCourseAsync(string _course)
        {
            if (db != null)
            {
                var students = await db.Students.Where(student => student.CourseId == _course).ToListAsync();
                return _mapper.Map<List<Student>>(students);
            }
            return null;
        }

        public async Task<Teacher> GetTeacherByEmailAsync(string email)
        {
            if (db != null)
            {
                var record = await db.Teachers.FirstOrDefaultAsync(teacher => teacher.Email == email);
                return record;
            }
            return null;
        }

        public async Task<List<Teacher>> GetTeachersByNameAsync(string name)
        {
            if (db != null)
            {
                var teachers = await db.Teachers.Where(teacher => teacher.Name == name).ToListAsync();
                return _mapper.Map<List<Teacher>>(teachers);
            }
            return null;
        }

        public async Task<List<Teacher>> GetTeachersByDepartmentAsync(string department)
        {
            if(db != null)
            {
                var teachers = await db.Teachers.Where(teacher => teacher.Department == department).ToListAsync();
                return _mapper.Map<List<Teacher>>(teachers);
            }
            return null;
        }

        public async Task UpdateStudentAsync(StudentViewModel student, int id)
        {
            var updated_student = new Student() 
            {
                StudentId = id,
                Name = student.Name,
                RollNo = student.RollNo,
                ClassId = student.ClassId,
                Dob = student.Dob,
                Contact = student.Contact,
                Email = student.Email,
                Address = student.Address,
                CourseId = student.CourseId,
            };

            db.Students.Update(updated_student);
            await db.SaveChangesAsync();
        }

        public async Task UpdateTeacherAsync(TeacherViewModel teacher, int teacher_id)
        {
            var updated_teacher = new Teacher()
            {
                TeacherId = teacher_id,
                Name = teacher.Name,
                Dob = teacher.Dob,
                Department = teacher.Department,
                Contact = teacher.Contact,
                Email = teacher.Email,
                Address = teacher.Address,
                Salary = teacher.Salary,
            };

            db.Teachers.Update(updated_teacher);
            await db.SaveChangesAsync();
        }

        public int GetLoginId(string email)
        {
            if(db != null)
            {
                Login loginInfo = db.Logins.FirstOrDefault(login => login.Username == email);
                return loginInfo.LoginId;
            }

            return -1;
        }
    }
}
