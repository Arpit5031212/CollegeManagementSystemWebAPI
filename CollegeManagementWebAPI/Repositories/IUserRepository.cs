using CollegeManagementWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementWebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<List<Teacher>> GetAllTeachersAsync();
        
        Task<Student> GetStudentByRollAsync(int roll);
        Task<List<Student>> GetStudentsByNameAsync(string name);
        Task<Student> GetStudentByEmailAsync(string email);
        Task<List<Teacher>> GetTeachersByNameAsync(string name);
        Task<Teacher> GetTeacherByEmailAsync(string email);

        Task<List<Student>> GetStudentsByCourseAsync(string _course);
        Task<List<Student>> GetStudentsByClassAsync(string _class);
        Task<List<Teacher>> GetTeachersByDepartmentAsync(string department);        
        Task<Student> CreateStudentAsync(Student student);
        Task<Teacher> CreateTeacherAsync(Teacher teacher);

        Task<Student> UpdateStudentAsync(Student student);
        Task<Teacher> UpdateTeacherAsync(Teacher teacher);

        Task DeleteStudentAsync(int roll);
        Task DeleteTeacherAsync(string email);

    }
}
