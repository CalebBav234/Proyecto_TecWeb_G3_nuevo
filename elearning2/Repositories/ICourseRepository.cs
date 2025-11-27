using elearning2.Models;

namespace elearning2.Repositories
{
   public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course?> GetById(Guid courseId);
        Task AddCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(Course course);
    }
}