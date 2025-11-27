using Microsoft.EntityFrameworkCore;
using elearning2.Data;
using elearning2.Models;

namespace elearning2.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _db;
        public CourseRepository(AppDbContext db)
        {
            _db = db;
        }
        public Task AddCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetById(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetBYTeacher(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}