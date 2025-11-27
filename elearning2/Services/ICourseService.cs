using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using elearning2.Models;

namespace elearning2.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course?> GetById(Guid courseId);
        Task<Course> AddCourse(Course course);
        Task<Course?> UpdateCourse(Guid courseId, Course updatedCourse);
        Task<bool> DeleteCourse(Guid courseId);
        Task<IEnumerable<Course>> GetByTeacher(Guid teacherId);
        Task<Course?> GetByTitle(string title);
    }
}