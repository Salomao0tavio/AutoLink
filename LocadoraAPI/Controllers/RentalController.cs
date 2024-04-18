using LocadoraAPI.Entities;
using LocadoraAPI.Models.CreateModels;
using LocadoraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a aluguéis.
    /// </summary>
    [Route("api/aluguel")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// Construtor do RentalController.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public RentalController(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtém todos os aluguéis.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var rents = _context.Rentals.ToList();
            return Ok(rents);
        }

        /// <summary>
        /// Obtém um aluguel por ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var rent = _context.Rentals.SingleOrDefault(r => r.ID == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            return Ok(rent);
        }

        /// <summary>
        /// Adiciona um novo aluguel.
        /// </summary>
        [HttpPost]
        public IActionResult Post(RentalCreateModel rent)
        {
            if (rent == null)
            {
                return BadRequest("Dados de aluguel inválidos.");
            }

            if (_context.Rentals.Any(r => r.ID == rent.Id))
            {
                return Conflict("Já existe um aluguel com este ID.");
            }

            _context.Rentals.Add(Rental.Parse(rent));
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = rent.Id }, rent);
        }

        /// <summary>
        /// Atualiza um aluguel existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Rental input)
        {
            var rent = _context.Rentals.SingleOrDefault(r => r.ID == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            if (input.EndDate < input.BeginDate)
            {
                return BadRequest("Data de fim menor que data de início.");
            }

            rent.Update(input.Vehicle, input.BeginDate, input.EndDate, input.Price);

            return NoContent();
        }

        /// <summary>
        /// Remove um aluguel por ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rent = _context.Rentals.SingleOrDefault(r => r.ID == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            _context.Rentals.Remove(rent);

            return NoContent();
        }
    }
}
