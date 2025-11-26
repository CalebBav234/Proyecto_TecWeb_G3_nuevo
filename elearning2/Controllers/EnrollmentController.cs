using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Services;

namespace elearning2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetAllEnrollments([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var enrollments = await _service.GetAll();
                var pagedEnrollments = enrollments.Skip((page - 1) * limit).Take(limit);

                return Ok(new { Enrollments = pagedEnrollments, Page = page, Limit = limit,Total = enrollments.Count() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving enrollments.", Details = ex.Message });
            }
        }


        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetEnrollment(Guid id)
        {
            try
            {
                var enrollment = await _service.GetOne(id);
                if (enrollment == null)
                {
                    return NotFound(new { Message = "Enrollment not found." });
                }

                return Ok(enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while retrieving the enrollment.",
                    Details = ex.Message
                });
            }
        }

        [HttpGet("student/{studentId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetEnrollmentsByStudent(Guid studentId, [FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var enrollments = await _service.GetByStudentId(studentId);
                var pagedEnrollments = enrollments.Skip((page - 1) * limit).Take(limit);

                return Ok(new
                {
                    Enrollments = pagedEnrollments,
                    Page = page,
                    Limit = limit,
                    Total = enrollments.Count()
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while retrieving enrollments by student.",
                    Details = ex.Message
                });
            }
        }

        [HttpGet("course/{courseId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetEnrollmentsByCourse(Guid courseId, [FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var enrollments = await _service.GetByCourseId(courseId);
                var pagedEnrollments = enrollments.Skip((page - 1) * limit).Take(limit);

                return Ok(new
                { Enrollments = pagedEnrollments, Page = page,  Limit = limit, Total = enrollments.Count() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {  Message = "An error occurred while retrieving enrollments by course.", Details = ex.Message }); 
            }
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateEnrollment([FromBody] CreateEnrollmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            try
            {
               
                var enrollment = await _service.CreateEnrollment(dto);
                return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, enrollment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while creating the enrollment.", Details = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateEnrollment([FromBody] UpdateEnrollmentDto dto, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            try
            {
                var updated = await _service.UpdateEnrollment(dto, id);
                if (updated == null)
                {
                    return NotFound(new { Message = "Enrollment not found." });
                }

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while updating the enrollment.", Details = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteEnrollment(Guid id)
        {
            try
            {
                var deleted = await _service.DeleteEnrollment(id);
                if (!deleted)
                {
                    return NotFound(new { Message = "Enrollment not found." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while deleting the enrollment.", Details = ex.Message });
            }
        }
    }

}
