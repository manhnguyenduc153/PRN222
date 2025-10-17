using System.ComponentModel.DataAnnotations;

namespace ApiWithRoles.Models
{
    public class FileUploadRequest
    {
        [Required]
        public IFormFile File { get; set; }
    }

    public class FileUploadResponse
    {
        public bool Success { get; set; }
        public string? FileUrl { get; set; }
        public string? ErrorMessage { get; set; }
    }

    internal class GitHubFileContent
    {
        public string message { get; set; }
        public string content { get; set; }
    }

    internal class GitHubApiResponse
    {
        public GitHubContent content { get; set; }
    }

    internal class GitHubContent
    {
        public string download_url { get; set; }
    }
}
