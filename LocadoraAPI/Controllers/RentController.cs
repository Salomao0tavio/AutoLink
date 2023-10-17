using LocadoraAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    [Route("api/rent")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly RentDbContext _context;

        public RentController(RentDbContext context)
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
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            return Ok(rent);
        }

        // POST: api/rent
        [HttpPost]
        public IActionResult Post(Rent rent)
        {
            if (rent == null)
            {
                return BadRequest("Dados de aluguel inválidos.");
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
        public IActionResult Update(int id, Rent input)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            var rent = _context.Rents.SingleOrDefault(r => r.Id == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            rent.Update(input.Vehicle, input.StartDate, input.EndDate, input.Price);
            

            return NoContent();
        }

        // DELETE: api/rent/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

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
