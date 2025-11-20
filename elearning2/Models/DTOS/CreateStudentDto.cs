using System.ComponentModel.DataAnnotations;

namespace elearning2.Models.DTOS
{
    public record CreateStudentDto
    {
        [Required]
        public Guid UserId { get; init; }
        [Required]
        public string FullName { get; init; }
        public string? Bio { get; init; }
        public string? AvatarUrl { get; init; }
    }
}
