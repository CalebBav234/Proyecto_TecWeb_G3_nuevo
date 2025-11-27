using System;
using System.Collections.Generic;
using elearning2.Models;

namespace elearning2.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseService _repo;
        public CourseService(ICourseService repo)
        {
            _repo = repo;
        }
        public Task<Course> AddCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourse(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _repo.GetAllCourses();
        }

        public async Task<Course?> GetById(Guid courseId)
        {
            return await _repo.GetById(courseId);
        }

        public Task<IEnumerable<Course>> GetByTeacher(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> UpdateCourse(Guid courseId, Course updatedCourse)
        {
            throw new NotImplementedException();
        }
    }
}