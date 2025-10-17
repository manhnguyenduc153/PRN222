using ApiWithRoles.Entities;
using ApiWithRoles.Models;

namespace ApiWithRoles.Services.IServices
{
    public interface IStudentService
    {
        Task<ResponseData<IEnumerable<StudentModel>>> GetListPaging(StudentSearchModel search);
        Task<ResponseData<StudentModel>> GetById(long id);
        Task<ResponseData<object>> Insert(StudentSaveModel model);
        Task<ResponseData<object>> Update(StudentSaveModel model);
        Task<ResponseData<object>> Delete(long id);
    }
}
