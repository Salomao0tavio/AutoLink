using LocadoraAPI.Entities;
using LocadoraAPI.Models.CreateModels;
using LocadoraAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocadoraAPI.Controllers
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
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Customers.ToList());
        }

        /// <summary>
        /// Obtém um cliente por ID.
        /// </summary>
        [HttpGet("{id}")]
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
        [HttpPost]
        public IActionResult Create(CustomerCreateModel customer)
        {
            _context.Customers.Add(Customer.Parse(customer));
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Remove um cliente por ID.
        /// </summary>
        [HttpDelete("{id}")]
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
        [HttpGet("{id}/alugueis")]
        public IActionResult GetRents(int id)
        {
            var customer = _context.Customers.Find(id) ?? throw new ArgumentNullException("Cliente não encontrado.");

            return Ok(customer.Rentals);
        }
    }
}
