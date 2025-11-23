using System.ComponentModel.DataAnnotations;

namespace elearning2.Models;

public class Student
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FullName { get; set; } = null!;
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }

    public User User { get; set; } = null!;

    public Certificate? Certificate { get; set; }
}
