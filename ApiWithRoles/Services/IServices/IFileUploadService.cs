using ApiWithRoles.Models;
using ApiWithRoles.Models;

namespace ApiWithRoles.Services
{
    public interface IFileUploadService
    {
        Task<FileUploadResponse> UploadFileAsync(IFormFile file);
    }
}