using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Teachers;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
 
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService teacherService)
        {
            _service = teacherService;           
        }


        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherCreateDto request)
        {
            await _service.Create(request);
            return CreatedAtAction(nameof(Create), new {Response = "Data succesfully created"});
        }
    }
}
