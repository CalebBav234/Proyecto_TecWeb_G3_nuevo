using System;
using System.Collections.Generic;
using elearning2.Models;
using elearning2.Models.DTOS;
using elearning2.Repositories;

namespace elearning2.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        public CourseService(ICourseRepository repo)
        {
            _repo = repo;
        }
        public async Task DeleteCourse(Guid courseId)
        {
            Course? course = (await GetAllCourses()).FirstOrDefault(c => c.Id == courseId);
            if (course == null) return;
            await _repo.DeleteCourse(course);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _repo.GetAll();
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