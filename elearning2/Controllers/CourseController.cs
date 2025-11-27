using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using elearning2.Services;
using elearning2.Models;

namespace elearning2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
           IEnumerable<Course> courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var course = await _courseService.GetById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }
    }
}