using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Services;

namespace elearning2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllLessons([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var lessons = await _service.GetAll();
                var pagedLessons = lessons.Skip((page - 1) * limit).Take(limit);
                return Ok(new { Lessons = pagedLessons, Page = page, Limit = limit, Total = lessons.Count() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving lessons.", Details = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetLesson(Guid id)
        {
            try
            {
                var lesson = await _service.GetOne(id);
                if (lesson == null)
                {
                    return NotFound(new { Message = "Lesson not found." });
                }
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the lesson.", Details = ex.Message });
            }
        }

        [HttpGet("course/{courseId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetLessonsByCourseId(Guid courseId, [FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var lessons = await _service.GetByCourseId(courseId);
                var pagedLessons = lessons.Skip((page - 1) * limit).Take(limit);
                return Ok(new { Lessons = pagedLessons, Page = page, Limit = limit, Total = lessons.Count() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving lessons by course ID.", Details = ex.Message });
            }
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> GetLessonByTitle([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest(new { Message = "Title is required for search." });
            }
            try
            {
                var lesson = await _service.GetByTitle(title);
                if (lesson == null)
                {
                    return NotFound(new { Message = "Lesson not found with the given title." });
                }
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while searching for the lesson.", Details = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateLesson([FromBody] CreateLessonDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var lesson = await _service.CreateLesson(dto);
                return CreatedAtAction(nameof(GetLesson), new { id = lesson.Id }, lesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the lesson.", Details = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateLesson([FromBody] UpdateLessonDto dto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var lesson = await _service.UpdateLesson(dto, id);
                return Ok(lesson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the lesson.", Details = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            try
            {
                await _service.DeleteLesson(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the lesson.", Details = ex.Message });
            }
        }
    }
}
