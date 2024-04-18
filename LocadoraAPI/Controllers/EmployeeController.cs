using LocadoraAPI.Entities;
using LocadoraAPI.Models.CreateModels;
using LocadoraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Context _context;

        public EmployeeController(Context context)
        {
            _context = context;
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost]
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

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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
