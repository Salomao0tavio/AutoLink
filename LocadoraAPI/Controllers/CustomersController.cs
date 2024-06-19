using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Data;
using Models.CreateModels;
using Models;

namespace Controllers
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a clientes.
    /// </summary>
    [Route("api/clientes")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// Construtor do CustomersController.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public CustomersController(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtém todos os clientes.
        /// </summary>
        /// <returns>Lista de todos os clientes.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os clientes.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os clientes retornada com sucesso.")]
        public IActionResult GetAll()
        {
            return Ok(_context.Customers.ToList());
        }

        /// <summary>
        /// Obtém um cliente por ID.
        /// </summary>
        /// <param name="id">ID do cliente.</param>
        /// <returns>Detalhes do cliente especificado.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um cliente por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Detalhes do cliente retornados com sucesso.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cliente não encontrado.")]
        public IActionResult GetById(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(customer);
        }

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="customer">Dados do cliente a ser criado.</param>
        /// <returns>Status de criação do cliente.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo cliente.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Cliente criado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dados de cliente inválidos.")]
        public IActionResult Create(CustomerCreateModel customer)
        {
            if (customer == null)
            {
                return BadRequest("Dados de cliente inválidos.");
            }

            _context.Customers.Add(Customer.Parse(customer));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Remove um cliente por ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser removido.</param>
        /// <returns>Status de remoção do cliente.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um cliente por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cliente removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cliente não encontrado.")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Cliente removido com sucesso.");
        }

        /// <summary>
        /// Obtém os aluguéis de um cliente por ID.
        /// </summary>
        /// <param name="id">ID do cliente.</param>
        /// <returns>Lista de aluguéis do cliente especificado.</returns>
        [HttpGet("{id}/alugueis")]
        [SwaggerOperation(Summary = "Obtém os aluguéis de um cliente por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de aluguéis do cliente retornada com sucesso.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cliente não encontrado.")]
        public IActionResult GetRents(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(customer.Rentals);
        }
    }
}
