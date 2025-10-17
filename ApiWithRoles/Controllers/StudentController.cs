using ApiWithRoles.Models;
using ApiWithRoles.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApiWithRoles.Entities;

namespace ApiWithRoles.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("api/get-list")]
        public async Task<IActionResult> GetList([FromQuery] StudentSearchModel model)
        {
            var result = await _studentService.GetListPaging(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("api/get-by-id")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _studentService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/add")]
        public async Task<IActionResult> AddAsync(StudentSaveModel model)
        {
            var result = await _studentService.Insert(model);

            return Ok(result);
        }

        [HttpPut]
        [Route("api/update")]
        public async Task<IActionResult> UpdateAsync(StudentSaveModel model)
        {
            var result = await _studentService.Update(model);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/delete")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _studentService.Delete(id);

            return Ok(result);
        }
    }
}
