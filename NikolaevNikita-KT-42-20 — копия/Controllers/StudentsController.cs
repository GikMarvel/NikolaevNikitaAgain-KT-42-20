using NikolaevNikita_KT_42_20.Filters;
using NikolaevNikita_KT_42_20.Interfaces.StudentsInterfaces;
using NikolaevNikita_KT_42_20.Models;
using NikolaevNikita_KT_42_20.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace NikolaevNikita_KT_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;
        private readonly StudentDbContext _dbContext;
        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService, StudentDbContext dbContext)
        {
            _logger = logger;
            _studentService = studentService;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost]
        [Route("GetStudentsByName")]
        public async Task<IActionResult> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByNameAsync(filter, cancellationToken);
            return Ok(students);
        }

        [HttpPost]
        [Route("createStudent")]
        public async Task<IActionResult> CreateStudent(Student Student)
        {

            await _studentService.CreateStudent(Student);

            return Ok("create was successful");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student Student)
        {
            if (id != Student.StudentId)
            {
                return BadRequest();
            }

            try
            {
                await _studentService.UpdateStudent(Student);

                return Ok("update was successful");
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

        }

        // DELETE:
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            var Student = await _dbContext.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            await _studentService.DeleteStudent(Student);

            return Ok("removal was successful");
        }
    }
}