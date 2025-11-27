using elearning2.Models;

namespace elearning2.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAll();
        Task<Enrollment?> GetOne(Guid id);
        Task<IEnumerable<Enrollment>> GetByStudentId(Guid studentId);
        Task<IEnumerable<Enrollment>> GetByCourseId(Guid courseId);
        Task<Enrollment?> GetByStudentAndCourse(Guid studentId, Guid courseId);

        Task Add(Enrollment enrollment);
        Task Update(Enrollment enrollment);
        Task Delete(Enrollment enrollment);
    }
}