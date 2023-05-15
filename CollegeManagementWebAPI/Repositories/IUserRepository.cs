using CollegeManagementWebAPI.Models;
using CollegeManagementWebAPI.ViewModels;
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
        Task<StudentViewModel> AddStudentAsync(Student student);
        Task<Teacher> AddTeacherAsync(Teacher teacher);

        Task UpdateStudentAsync(Student student, int id);
        Task UpdateTeacherAsync(Teacher teacher, int teacher_id);

        Task DeleteStudentAsync(int roll);
        Task DeleteTeacherAsync(int teacher_id);
        int GetLoginId(string email);

        //Task<Login> AddUserInLoginTable(Login login);

    }
}
