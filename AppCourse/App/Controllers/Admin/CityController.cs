using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Admin.Cities;
using Service.Services.Interfaces;

namespace App.Controllers.Admin
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;

        public CityController(ICityService cityService,
                              ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get all method is working");
            return Ok(await _cityService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _cityService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            return Ok(await _cityService.GetByNameAsync(name));
        }

        [HttpGet]
        public async Task<IActionResult> GetPaginateDatas([FromQuery] int page = 1, [FromQuery] int take = 2)
        {
            return Ok(await _cityService.GetPaginateDatasAsync(page, take));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            await _cityService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });
        }

        [HttpGet]
        public async Task<IActionResult> Filter([FromQuery] string name, [FromQuery] string countryName)
        {
            return Ok(await _cityService.FilterAsync(name, countryName));
        }
    }
}
