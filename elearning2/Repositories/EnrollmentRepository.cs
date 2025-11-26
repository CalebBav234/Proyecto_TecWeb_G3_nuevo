using elearning2.Data;
using elearning2.Models;
using Microsoft.EntityFrameworkCore;

namespace elearning2.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment?> GetOne(Guid id)
        {
            return await _context.Enrollments
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Enrollment>> GetByStudentId(Guid studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetByCourseId(Guid courseId)
        {
            return await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Enrollment?> GetByStudentAndCourse(Guid studentId, Guid courseId)
        {
            return await _context.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public async Task Add(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}
