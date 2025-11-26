using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Repositories;

namespace elearning2.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;

        public EnrollmentService(IEnrollmentRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Enrollment>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Enrollment?> GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public Task<IEnumerable<Enrollment>> GetByStudentId(Guid studentId)
        {
            return _repository.GetByStudentId(studentId);
        }

        public Task<IEnumerable<Enrollment>> GetByCourseId(Guid courseId)
        {
            return _repository.GetByCourseId(courseId);
        }

        public async Task<Enrollment> CreateEnrollment(CreateEnrollmentDto dto)
        {
     
            var existing = await _repository.GetByStudentAndCourse(dto.StudentId, dto.CourseId);
            if (existing != null)
            {
                throw new InvalidOperationException("Enrollment already exists for this student and course.");
            }

            var enrollment = new Enrollment
            {
                Id = Guid.NewGuid(),
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                EnrolledAt = DateTime.UtcNow
            };

            await _repository.Add(enrollment);
            return enrollment;
        }

        public async Task<Enrollment?> UpdateEnrollment(UpdateEnrollmentDto dto, Guid id)
        {
            var enrollment = await _repository.GetOne(id);
            if (enrollment == null)
            {
                return null;
            }

            if (dto.StudentId.HasValue)
            {
                enrollment.StudentId = dto.StudentId.Value;
            }

            if (dto.CourseId.HasValue)
            {
                enrollment.CourseId = dto.CourseId.Value;
            }

            await _repository.Update(enrollment);
            return enrollment;
        }

        public async Task<bool> DeleteEnrollment(Guid id)
        {
            var enrollment = await _repository.GetOne(id);
            if (enrollment == null)
            {
                return false;
            }

            await _repository.Delete(enrollment);
            return true;
        }
    }
}
