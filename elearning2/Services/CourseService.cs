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

        public Task<IEnumerable<Course>> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetById(Guid courseId)
        {
            throw new NotImplementedException();
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