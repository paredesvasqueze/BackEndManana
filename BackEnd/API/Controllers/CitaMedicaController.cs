using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaMedicaController : ControllerBase
    {
        private readonly ICitaMedicaService _service;
        private readonly ILogger<CitaMedicaController> _logger;

        public CitaMedicaController(ICitaMedicaService service, ILogger<CitaMedicaController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CitaMedica cita)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _service.AddAsync(cita);
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { Id = newId });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CitaMedica cita)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rows = await _service.UpdateAsync(cita);
            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rows = await _service.DeleteAsync(id);
            if (rows == 0)
                return NotFound();

            return NoContent();
        }
    }
}
