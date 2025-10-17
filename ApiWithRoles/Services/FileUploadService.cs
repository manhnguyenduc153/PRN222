using ApiWithRoles.Models;
using ApiWithRoles.Utils;

namespace ApiWithRoles.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _owner;
        private readonly string _repo;
        private readonly string _token;

        public FileUploadService(IConfiguration configuration)
        {
            _owner = configuration["GitHub:Owner"] ?? throw new ArgumentNullException("GitHub:Owner not configured");
            _repo = configuration["GitHub:Repository"] ?? throw new ArgumentNullException("GitHub:Repository not configured");
            _token = configuration["GitHub:Token"] ?? throw new ArgumentNullException("GitHub:Token not configured");
        }

        public async Task<FileUploadResponse> UploadFileAsync(IFormFile file)
        {
            return await GitHubUploader.UploadFileAsync(file, _owner, _repo, _token);
        }
    }
}