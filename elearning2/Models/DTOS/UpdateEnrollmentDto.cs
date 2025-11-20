namespace elearning2.Models.DTOS
{
    public record UpdateEnrollmentDto
    {
        public Guid? StudentId { get; init; }
        public Guid? CourseId { get; init; }
    }
}
