using ApiWithRoles.Models;
using System.Text;
using System.Text.Json;
using ApiWithRoles.Models;

namespace ApiWithRoles.Utils
{
    public static class GitHubUploader
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Upload file to GitHub repository and return download URL
        /// </summary>
        /// <param name="file">File to upload</param>
        /// <param name="owner">GitHub username</param>
        /// <param name="repo">Repository name</param>
        /// <param name="token">GitHub Personal Access Token</param>
        /// <returns>File download URL if successful</returns>
        public static async Task<FileUploadResponse> UploadFileAsync(
            IFormFile file,
            string owner,
            string repo,
            string token)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return new FileUploadResponse
                    {
                        Success = false,
                        ErrorMessage = "File is empty"
                    };
                }

                // Generate unique filename
                var fileName = GenerateUniqueFileName(file.FileName);

                // Convert file to base64
                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
                var base64Content = Convert.ToBase64String(fileBytes);

                // Prepare request
                var requestContent = new GitHubFileContent
                {
                    message = $"Upload {fileName}",
                    content = base64Content
                };

                var jsonContent = JsonSerializer.Serialize(requestContent);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Setup HTTP client
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"token {token}");
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "ASP.NET-Core-App");

                // Upload to GitHub
                var apiUrl = $"https://api.github.com/repos/{owner}/{repo}/contents/{fileName}";
                var response = await _httpClient.PutAsync(apiUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<GitHubApiResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return new FileUploadResponse
                    {
                        Success = true,
                        FileUrl = apiResponse?.content?.download_url
                    };
                }
                else
                {
                    return new FileUploadResponse
                    {
                        Success = false,
                        ErrorMessage = $"Upload failed: {response.StatusCode}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new FileUploadResponse
                {
                    Success = false,
                    ErrorMessage = $"Error: {ex.Message}"
                };
            }
        }

        private static string GenerateUniqueFileName(string originalFileName)
        {
            var fileExtension = Path.GetExtension(originalFileName);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            return $"{fileNameWithoutExtension}_{timestamp}{fileExtension}";
        }
    }
}