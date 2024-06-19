using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Models.CreateModels;
using Data;
using Models;

namespace Controllers
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a funcionários.
    /// </summary>
    [Route("api/funcionario")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Context _context;

        /// <summary>
        /// Construtor do EmployeeController.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public EmployeeController(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtém todos os funcionários.
        /// </summary>
        /// <returns>Lista de todos os funcionários.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os funcionários.")]
        [SwaggerResponse(200, "Lista de todos os funcionários retornada com sucesso.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_context.Employees.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém um funcionário por ID.
        /// </summary>
        /// <param name="id">ID do funcionário.</param>
        /// <returns>Detalhes do funcionário especificado.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um funcionário por ID.")]
        [SwaggerResponse(200, "Detalhes do funcionário retornados com sucesso.")]
        [SwaggerResponse(404, "Funcionário não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult Get(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    return NotFound("Funcionário não encontrado.");
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Adiciona um novo funcionário.
        /// </summary>
        /// <param name="employee">Dados do funcionário a ser criado.</param>
        /// <returns>Detalhes do funcionário criado.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo funcionário.")]
        [SwaggerResponse(201, "Funcionário criado com sucesso.")]
        [SwaggerResponse(400, "Dados de funcionário inválidos.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult Post(EmployeeCreateModel employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Funcionário inválido.");
                }

                _context.Employees.Add(Employee.Parse(employee));
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza um funcionário existente.
        /// </summary>
        /// <param name="id">ID do funcionário a ser atualizado.</param>
        /// <param name="employee">Dados atualizados do funcionário.</param>
        /// <returns>Resposta de status.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um funcionário existente.")]
        [SwaggerResponse(200, "Funcionário atualizado com sucesso.")]
        [SwaggerResponse(400, "ID do funcionário não corresponde.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult Put(Guid id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest("ID do funcionário não corresponde.");
                }

                _context.Employees.Update(employee);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove um funcionário por ID.
        /// </summary>
        /// <param name="id">ID do funcionário a ser removido.</param>
        /// <returns>Resposta de status.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um funcionário por ID.")]
        [SwaggerResponse(200, "Funcionário removido com sucesso.")]
        [SwaggerResponse(404, "Funcionário não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult Delete(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    return NotFound("Funcionário não encontrado.");
                }

                _context.Employees.Remove(employee);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
