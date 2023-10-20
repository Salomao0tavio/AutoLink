using LocadoraAPI.Entities;
using LocadoraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoDbContext _context;

        public VeiculoController(VeiculoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var vehicles = _context.Vehicles.ToList();
            return Ok(vehicles);
        }

        [HttpGet("{placa}")]
        public IActionResult GetByPlaca(string placa)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Placa == placa);

            if (vehicle == null)
            {
                return NotFound("Vehicle not found.");
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Post(Veiculo vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Invalid vehicle data.");
            }

            _context.Vehicles.Add(vehicle);
           

            return CreatedAtAction("GetByPlaca", new { placa = vehicle.Placa }, vehicle);
        }

        [HttpDelete("{placa}")]
        public IActionResult Delete(string placa)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Placa == placa);

            if (vehicle == null)
            {
                return NotFound("Vehicle not found.");
            }

            _context.Vehicles.Remove(vehicle);
           
            return NoContent();
        }

        [HttpPut("placa")]
        public IActionResult ChangeStatus(string placa, bool status)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Placa == placa);

            if (vehicle == null)
            {
                return NotFound("Vehicle not found.");
            }

            vehicle.Disponibilidade = status;            

            return Ok(vehicle);
        }
    }
}
