using System.ComponentModel.DataAnnotations;

namespace elearning2.Models.DTOS
{
    public record UpdateCourseDto
    {
        public string? Title { get; init; }
        public string? Description { get; init; }
        public Guid? TeacherId { get; init; }
    }
}
