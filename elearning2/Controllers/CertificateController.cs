using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Services;

namespace elearning2.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _service;

        public CertificateController(ICertificateService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCertificates([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            try
            {
                var certificates = await _service.GetAll();
                var pagedCertificates = certificates.Skip((page - 1) * limit).Take(limit);
                return Ok(new { Certificates = pagedCertificates, Page = page, Limit = limit, Total = certificates.Count() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving certificates.", Details = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetCertificate(Guid id)
        {
            try
            {
                var certificate = await _service.GetOne(id);
                if (certificate == null)
                {
                    return NotFound(new { Message = "Certificate not found." });
                }
                return Ok(certificate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the certificate.", Details = ex.Message });
            }
        }

        [HttpGet("student/{studentId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetCertificatesByStudentId(Guid studentId)
        {
            try
            {
                var certificates = await _service.GetByStudentId(studentId);
                if (!certificates.Any())
                {
                    return NotFound(new { Message = "No certificates found for the given student ID." });
                }
                return Ok(certificates);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving certificates by student ID.", Details = ex.Message });
            }
        }

        [HttpGet("title")]
        [Authorize]
        public async Task<IActionResult> GetCertificateByTitle([FromQuery] string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest(new { Message = "Title is required to search for certificate." });
            }
            try
            {
                var certificate = await _service.GetByTitle(title);
                if (certificate == null)
                {
                    return NotFound(new { Message = "Certificate not found with the given title." });
                }
                return Ok(certificate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the certificate by title.", Details = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateCertificate([FromBody] CreateCertificateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var certificate = new Certificate
                {
                    Id = Guid.NewGuid(),
                    StudentId = dto.StudentId,
                    Title = dto.Title,
                    Description = dto.Description
                };
                await _service.Add(certificate);
                return CreatedAtAction(nameof(GetCertificate), new { id = certificate.Id }, certificate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the certificate.", Details = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> UpdateCertificate(Guid id, [FromBody] UpdateCertificateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var existingCertificate = await _service.GetOne(id);
                if (existingCertificate == null)
                {
                    return NotFound(new { Message = "Certificate not found." });
                }
                existingCertificate.StudentId = dto.StudentId ?? existingCertificate.StudentId;
                existingCertificate.Title = dto.Title ?? existingCertificate.Title;
                existingCertificate.Description = dto.Description ?? existingCertificate.Description;
                await _service.Update(existingCertificate);
                return Ok(existingCertificate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the certificate.", Details = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteCertificate(Guid id)
        {
            try
            {
                var certificate = await _service.GetOne(id);
                if (certificate == null)
                {
                    return NotFound(new { Message = "Certificate not found." });
                }
                await _service.Delete(certificate);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the certificate.", Details = ex.Message });
            }
        }
    }
}
