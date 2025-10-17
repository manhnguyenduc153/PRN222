using ApiWithRoles.Entities;
using ApiWithRoles.Models;

namespace ApiWithRoles.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentModel>> GetListPaging(StudentSearchModel model);
        Task<Student> AddAsync(Student entity);
        Task<int> GetTotalRecord(StudentSearchModel model);
        Task<Student> GetByIdAsync(long id);
        Task UpdateAsync(Student entity);
        Task DeleteAsync(Student entity);
        Task<int> SaveChangesAsync();

    }
}
