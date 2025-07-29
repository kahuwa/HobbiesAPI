using HobbiesAPI.Entity;
using HobbiesAPI.Repositories;
using HobbiesAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HobbiesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HobbiesController : ControllerBase
    {

        private readonly IHobbiesService _service;
        public HobbiesController(IHobbiesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var hobbies = await _service.GetAllAsync();
            return Ok(hobbies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var hobby = await _service.GetByIdAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }
            return Ok(hobby);
        }
        [HttpPost]
        public async Task<IActionResult> CrateAsync([FromBody]Hobbies hobby)
        {
            if (hobby == null)
            {
                return BadRequest("Hobby cannot be null");
            }
            var createdHobby = await _service.CreateAsync(hobby);
            return Ok(hobby);
        }

    }
}
