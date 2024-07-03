using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Educations;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    public class EducationController : BaseController
    {
        private readonly IEducationService _educationService;
        
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EducationCreateDto request)
        {
            await _educationService.CreateAsync(request);

            return CreatedAtAction(nameof(Create),new {Response = "Successfull"});
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _educationService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _educationService.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] EducationEditDto request)
        {
            await _educationService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _educationService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> SortBy([FromQuery] string sortKey,bool isDescending)
        {
            return Ok(await _educationService.SortBy(sortKey,isDescending));
        }

        [HttpGet]
        public async Task<IActionResult> SearchByName([FromQuery]string name)
        {
            return Ok(await _educationService.SearchByName(name));
        }
    }
}
