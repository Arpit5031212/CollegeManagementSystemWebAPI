using AutoMapper;
using CollegeManagementWebAPI.Models;
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
        public Task<Student> CreateStudentAsync(Student student)
        {
            throw new System.NotImplementedException();
        }

        public Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteStudentAsync(int roll)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteTeacherAsync(string email)
        {
            throw new System.NotImplementedException();
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

        public Task<Student> UpdateStudentAsync(Student student)
        {
            throw new System.NotImplementedException();
        }

        public Task<Teacher> UpdateTeacherAsync(Teacher teacher)
        {
            throw new System.NotImplementedException();
        }
    }
}
