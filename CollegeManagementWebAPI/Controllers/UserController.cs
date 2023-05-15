using AutoMapper;
using CollegeManagementWebAPI.Models;
using CollegeManagementWebAPI.Repositories;
using CollegeManagementWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _userRepository.GetAllStudentsAsync();
            if(students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _userRepository.GetAllTeachersAsync();
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }

        [HttpPost("register/student")]
        public async Task<IActionResult> AddNewStudent([FromBody] Student student)
        {
            var id = await _userRepository.AddStudentAsync(student);
            return Ok(id);
        }

        [HttpPost("register/teacher")]
        public async Task<IActionResult> AddNewTeacher([FromBody] Teacher teacher)
        {
            var id = await _userRepository.AddTeacherAsync(teacher);
            return Ok(id);
        }

        [HttpGet("student/roll")]
        public async Task<IActionResult> GetStudentByRoll([FromBody] int roll)
        {
            Student student = await _userRepository.GetStudentByRollAsync(roll);
            
            StudentViewModel view_student = _mapper.Map<StudentViewModel>(student);
            int login = _userRepository.GetLoginId(student.Email);
            view_student.LoginId = login;
             
            return Ok(view_student);
        }


        

        [HttpGet("student/email")]
        public async Task<IActionResult> GetStudentByEmail([FromBody] string email)
        {
            Student student = await _userRepository.GetStudentByEmailAsync(email);
            return Ok(student);
        }

        [HttpGet("student/name")]
        public async Task<IActionResult> GetStudentByName([FromBody] string name)
        {
            List<Student> students = await _userRepository.GetStudentsByNameAsync(name);
            return Ok(students);
        }

        [HttpGet("student/class")]
        public async Task<IActionResult> GetStudentByClass([FromBody] string _class)
        {
            List<Student> students = await _userRepository.GetStudentsByClassAsync(_class);
            return Ok(students);
        }

        [HttpGet("student/course")]
        public async Task<IActionResult> GetStudentByCourse([FromBody] string course)
        {
            List<Student> students = await _userRepository.GetStudentsByCourseAsync(course);
            return Ok(students);
        }

        [HttpGet("teacher/name")]
        public async Task<IActionResult> GetTeacherByName([FromBody] string name)
        {
            List<Teacher> teachers = await _userRepository.GetTeachersByNameAsync(name);
            return Ok(teachers);
        }

        [HttpGet("teacher/department")]
        public async Task<IActionResult> GetTeacherByDepartment([FromBody] string department)
        {
            List<Teacher> teachers = await _userRepository.GetTeachersByDepartmentAsync(department);
            return Ok(teachers);
        }

        [HttpPut("teacher/update/{id}")]

        public async Task<IActionResult> UpdateTeacher([FromBody] Teacher teacher, [FromRoute] int id)
        {
            await _userRepository.UpdateTeacherAsync(teacher, id);
            return Ok();
        }

        [HttpPut("student/update/{id}")]

        public async Task<IActionResult> UpdateStudent([FromBody] Student student, [FromRoute] int id)
        {
            await _userRepository.UpdateStudentAsync(student, id);
            return Ok();
        }

        [HttpDelete("student/delete")]
        public async Task<IActionResult> DeleteStudent([FromBody] int roll)
        {
            await _userRepository.DeleteStudentAsync(roll);
            return Ok();
        }

        [HttpDelete("teacher/delete")]
        public async Task<IActionResult> DeleteTeacher([FromBody] int id)
        {
            await _userRepository.DeleteTeacherAsync(id);
            return Ok();
        }




    }
}
