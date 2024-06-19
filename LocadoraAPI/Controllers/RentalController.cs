using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Data;
using Models;
using Models.CreateModels;

namespace Controllers
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
        /// <returns>Lista de todos os aluguéis.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os aluguéis.")]
        [SwaggerResponse(200, "Lista de todos os aluguéis retornada com sucesso.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult GetAll()
        {
            var rents = _context.Rentals.ToList();
            return Ok(rents);
        }

        /// <summary>
        /// Obtém um aluguel por ID.
        /// </summary>
        /// <param name="id">ID do aluguel.</param>
        /// <returns>Detalhes do aluguel especificado.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um aluguel por ID.")]
        [SwaggerResponse(200, "Detalhes do aluguel retornados com sucesso.")]
        [SwaggerResponse(404, "Aluguel não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="rent">Dados do aluguel a ser criado.</param>
        /// <returns>Detalhes do aluguel criado.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo aluguel.")]
        [SwaggerResponse(201, "Aluguel criado com sucesso.")]
        [SwaggerResponse(400, "Dados de aluguel inválidos.")]
        [SwaggerResponse(409, "Já existe um aluguel com este ID.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="id">ID do aluguel a ser atualizado.</param>
        /// <param name="input">Dados atualizados do aluguel.</param>
        /// <returns>Resposta de status.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um aluguel existente.")]
        [SwaggerResponse(204, "Aluguel atualizado com sucesso.")]
        [SwaggerResponse(400, "Data de fim menor que data de início.")]
        [SwaggerResponse(404, "Aluguel não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="id">ID do aluguel a ser removido.</param>
        /// <returns>Resposta de status.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um aluguel por ID.")]
        [SwaggerResponse(204, "Aluguel removido com sucesso.")]
        [SwaggerResponse(404, "Aluguel não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult Delete(Guid id)
        {
            var rent = _context.Rentals.SingleOrDefault(r => r.ID == id);

            if (rent == null)
            {
                return NotFound("Aluguel não encontrado.");
            }

            _context.Rentals.Remove(rent);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
