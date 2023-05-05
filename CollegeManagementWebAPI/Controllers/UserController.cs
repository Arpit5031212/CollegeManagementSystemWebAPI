using CollegeManagementWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CollegeManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
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

    }
}
