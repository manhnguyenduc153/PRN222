using ApiWithRoles.Models;
using ApiWithRoles.Services;
using Microsoft.AspNetCore.Mvc;
using ApiWithRoles.Models;
using ApiWithRoles.Services;

namespace ApiWithRoles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        [HttpPost]
        public async Task<ActionResult<FileUploadResponse>> UploadFile([FromForm] FileUploadRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid file");
            }

            var result = await _fileUploadService.UploadFileAsync(request.File);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}