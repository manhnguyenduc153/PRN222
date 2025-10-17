using ApiWithRoles.Entities;
using ApiWithRoles.Enums;
using ApiWithRoles.Models;
using ApiWithRoles.Repository.IRepository;
using ApiWithRoles.Services.IServices;
using Mapster;

namespace ApiWithRoles.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentService> _logger;
        public StudentService(IStudentRepository studentRepository, ILogger<StudentService> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        //public async Task<IEnumerable<StudentModel>> GetListPaging(StudentSearchModel search)
        //{
        //    try
        //    {
        //        var totalRecord = await _studentRepository.GetTotalRecord(search);

        //        IEnumerable<StudentModel> lstStudent = new List<StudentModel>();

        //        if (totalRecord > 0)
        //        {
        //            lstStudent = await _studentRepository.GetListPaging(search);
        //        }

        //        var pageList = new PagedList<StudentModel>(lstStudent, totalRecord, search.PageIndex, search.PageSize);

        //        return pageList;

        //    }
        //    catch(Exception ex)
        //    {
        //        return new PagedList<StudentModel>(new List<StudentModel>(), 0, search.PageIndex, search.PageSize);
        //    }
        //}

        public async Task<ResponseData<IEnumerable<StudentModel>>> GetListPaging(StudentSearchModel search)
        {
            try
            {
                var totalRecord = await _studentRepository.GetTotalRecord(search);
                if (totalRecord > 0)
                {
                    var list = await _studentRepository.GetListPaging(search);
                    var pagedList = new PagedList<StudentModel>(list, totalRecord, search.PageIndex, search.PageSize);
                    return new ResponseData<IEnumerable<StudentModel>>(true, pagedList, pagedList.GetMetaData());
                }
                return new ResponseData<IEnumerable<StudentModel>>(true);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                return new ResponseData<IEnumerable<StudentModel>>(ex.Message);
            }
        }

        public async Task<ResponseData<object>> Insert(StudentSaveModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Name) || model.Age <= 0)
                    return new ResponseData<object>(ErrorCodeAPI.InvalidInput);

                var entity = model.Adapt<Student>();
                var result = await _studentRepository.AddAsync(entity);

                if (result != null)
                    return new ResponseData<object>(true, entity); // trả về entity vừa tạo

                return new ResponseData<object>(ErrorCodeAPI.NotOk);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResponseData<object>(ex.Message);
            }
        }

        public async Task<ResponseData<object>> Update(StudentSaveModel model)
        {
            try
            {
                if (model.Id <= 0 || string.IsNullOrWhiteSpace(model.Name) || model.Age <= 0)
                    return new ResponseData<object>(ErrorCodeAPI.InvalidInput);

                var entity = await _studentRepository.GetByIdAsync(model.Id);
                if (entity == null)
                    return new ResponseData<object>(ErrorCodeAPI.NotFound);

                var updateEntity = model.Adapt(entity);
                await _studentRepository.UpdateAsync(updateEntity);

                var result = await _studentRepository.SaveChangesAsync();

                return new ResponseData<object>(true, updateEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResponseData<object>(ex.Message);
            }
        }

        public async Task<ResponseData<StudentModel>> GetById(long id)
        {
            try
            {
                if (id <= 0)
                    return new ResponseData<StudentModel>(ErrorCodeAPI.InvalidInput);

                var entity = await _studentRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    return new ResponseData<StudentModel>(ErrorCodeAPI.NotFound);
                }
                    
                var model = entity.Adapt<StudentModel>();
                return new ResponseData<StudentModel>(true, model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResponseData<StudentModel>(ex.Message);
            }
        }

        public async Task<ResponseData<object>> Delete(long id)
        {
            try
            {
                if (id <= 0)
                    return new ResponseData<object>(ErrorCodeAPI.InvalidInput);

                var entity = await _studentRepository.GetByIdAsync(id);
                if (entity == null)
                {
                    return new ResponseData<object>(ErrorCodeAPI.NotFound);
                }
                    
                await _studentRepository.DeleteAsync(entity);
                return new ResponseData<object>(true, entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ResponseData<object>(ex.Message);
            }
        }
    }
}
