using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistoriaClinicaController : ControllerBase
    {
        private readonly IHistoriaClinicaService _service;
        private readonly ILogger<HistoriaClinicaController> _logger;

        public HistoriaClinicaController(IHistoriaClinicaService service, ILogger<HistoriaClinicaController> logger)
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
        public async Task<IActionResult> Create([FromBody] HistoriaClinica historiaclinica)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newId = await _service.AddAsync(historiaclinica);
            return CreatedAtAction(nameof(GetById), new { id = newId }, new { Id = newId });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] HistoriaClinica historiaclinica)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rows = await _service.UpdateAsync(historiaclinica);
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