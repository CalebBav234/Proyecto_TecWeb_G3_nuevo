using elearning2.Models;

namespace elearning2.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student?> GetOne(Guid id);
        Task<Student?> GetByUserId(Guid userId);
        Task<Student?> GetByFullName(string fullName);
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(Student student);
    }
}
