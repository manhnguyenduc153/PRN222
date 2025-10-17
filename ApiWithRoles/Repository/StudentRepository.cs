using Dapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using System.Text;
using ApiWithRoles.Data;
using ApiWithRoles.Entities;
using ApiWithRoles.Models;
using ApiWithRoles.Repository.IRepository;
using ApiWithRoles.Utilities;

namespace ApiWithRoles.Repository
{
    public class StudentRepository : BaseRepository<Student, long, AppDbContext>, IStudentRepository
    {
        public StudentRepository(AppDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
        }

        public async Task<IEnumerable<StudentModel>> GetListPaging(StudentSearchModel search)
        {
            if (search == null)
            {
                return null;
            }

            DynamicParameters dynamicParameters = new DynamicParameters();
            StringBuilder query = new StringBuilder(@"SELECT s.Id, s.Name, s.Age FROM Students s WHERE 1=1 ");

            if(!string.IsNullOrEmpty(search.Keyword))
            {
                query.Append(" AND s.Name LIKE @keyword");
                dynamicParameters.Add("keyword", "%" + search.Keyword + "%");
            }

            query.Append(" ORDER BY s.Id DESC ");
            StringUtils.AddPaging(query, search.PageIndex, search.PageSize);

            IEnumerable<StudentModel> lstStudent = await DapperQueryAsync<StudentModel>(query.ToString(), dynamicParameters);

            return lstStudent;
        }

        public async Task<int> GetTotalRecord(StudentSearchModel search)
        {
            if (search == null)
            {
                return 0;
            }

            DynamicParameters dynamicParameters = new DynamicParameters();
            StringBuilder query = new StringBuilder(@"SELECT COUNT(1) FROM Students s WHERE 1=1 ");

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query.Append(" AND s.Name LIKE @keyword");
                dynamicParameters.Add("keyword", "%" + search.Keyword + "%");
            }

            var count = await DapperGetAsync<int>(query.ToString(), dynamicParameters);

            return count;
        }
    }
}
