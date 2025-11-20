using System.ComponentModel.DataAnnotations;

namespace elearning2.Models.DTOS
{
    public record CreateEnrollmentDto
    {
        [Required]
        public Guid StudentId { get; init; }
        [Required]
        public Guid CourseId { get; init; }
    }
}
