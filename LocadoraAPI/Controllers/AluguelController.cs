using LocadoraAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    [Route("api/rent")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private readonly AluguelDbContext _context;

        public AluguelController(AluguelDbContext context)
        {
            _context = context;
        }

        // GET: api/rent
        [HttpGet]
        public IActionResult GetAll()
        {
            var rents = _context.Rents.ToList();
            return Ok(rents);
        }

        // GET: api/rent/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)        {
            

            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            return Ok(rent);
        }

        // POST: api/rent
        [HttpPost]
        public IActionResult Post(Aluguel rent)
        {
            if (rent == null)
            {
                return BadRequest("Dados de aluguel inválidos.");
            }

            if (rent.Id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            if (_context.Rents.Any(r => r.Id == rent.Id))
            {
                return Conflict("Já existe um aluguel com este ID.");
            }

            _context.Rents.Add(rent);
            return CreatedAtAction("GetById", new { id = rent.Id }, rent);
        }

        // PUT: api/rent/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Aluguel input)
        {
            
            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            rent.Update(input.Veiculo, input.DataInicio, input.DataFim, input.Preco);
            

            return NoContent();
        }

        // DELETE: api/rent/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            _context.Rents.Remove(rent);
            

            return NoContent();
        }
    }
}
