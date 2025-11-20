using System.ComponentModel.DataAnnotations;

namespace elearning2.Models.DTOS
{
    public record CreateCourseDto
    {
        [Required]
        public string Title { get; init; }
        public string? Description { get; init; }
        [Required]
        public Guid TeacherId { get; init; }
    }
}
