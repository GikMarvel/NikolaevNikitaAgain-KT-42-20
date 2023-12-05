using NikolaevNikita_KT_42_20.Database;
using NikolaevNikita_KT_42_20.Models;
using Microsoft.AspNetCore.Mvc;
using NikolaevNikita_KT_42_20.Interfaces.IGroupInterfaces;

namespace NikolaevNikita_KT_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private StudentDbContext _context;

        public CoursesController(ILogger<CoursesController> logger, StudentDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("AddCourse", Name = "AddCourse")]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
            return Ok(course);
        }

        [HttpPut("EditCourse")]
        public IActionResult UpdateCourse(string title, [FromBody] Course updatedCourse)
        {
            var existingCourse = _context.Courses.FirstOrDefault(g => g.Title == title);

            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Title = updatedCourse.Title;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(string title, Course updatedCourse)
        {
            var existingCourse = _context.Courses.FirstOrDefault(g => g.Title == title);

            if (existingCourse == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(existingCourse);
            _context.SaveChanges();

            return Ok();
        }
    }
}