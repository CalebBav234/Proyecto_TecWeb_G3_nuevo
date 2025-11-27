using elearning2.Models;
using elearning2.Models.DTOS;

namespace elearning2.Services
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAll();
        Task<Enrollment?> GetOne(Guid id);
        Task<IEnumerable<Enrollment>> GetByStudentId(Guid studentId);
        Task<IEnumerable<Enrollment>> GetByCourseId(Guid courseId);

        Task<Enrollment> CreateEnrollment(CreateEnrollmentDto dto);
        Task<Enrollment?> UpdateEnrollment(UpdateEnrollmentDto dto, Guid id);
        Task<bool> DeleteEnrollment(Guid id);
    }
}