namespace elearning2.Models.DTOS
{
    public record UpdateLessonDto
    {
        public Guid? CourseId { get; init; }
        public string? Title { get; init; }
        public string? Content { get; init; }
    }
}
