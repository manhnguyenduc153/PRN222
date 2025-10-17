using ApiWithRoles.Data;
using ApiWithRoles.Repository;
using ApiWithRoles.Repository.IRepository;
using ApiWithRoles.Services;
using ApiWithRoles.Services.IServices;

namespace ApiWithRoles.Extensions
{
    public static class ServicesRegister
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            //services.RegisterMapsterConfiguration();
            services.AddScoped<IFileUploadService, FileUploadService>();

            services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
