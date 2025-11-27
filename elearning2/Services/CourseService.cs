using System;
using System.Collections.Generic;
using elearning2.Models;
using elearning2.Models.DTOS;

namespace elearning2.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseService _repo;
        public CourseService(ICourseService repo)
        {
            _repo = repo;
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

        Task<Course> ICourseService.AddCourse(CreateCourseDto dto)
        {
            throw new NotImplementedException();
        }

        Task<Course?> ICourseService.UpdateCourse(UpdateCourseDto dto, Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}