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


    }
}