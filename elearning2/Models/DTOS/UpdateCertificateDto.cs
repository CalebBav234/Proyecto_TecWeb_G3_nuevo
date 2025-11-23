namespace elearning2.Models.DTOS
{
    public record UpdateCertificateDto
    {
        public Guid? StudentId { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
    }
}
