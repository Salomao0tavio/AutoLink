using LocadoraAPI.Entities;
using LocadoraAPI.Models.CreateModels;
using LocadoraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a veículos.
    /// </summary>
    [Route("api/veiculo")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly Context _context;

        public VehicleController(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Obtém todos os veículos.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var vehicles = _context.Vehicles.ToList();

                if (vehicles.Any())
                {
                    return Ok(vehicles);
                }
                return NotFound("Nenhum veiculo encontrado");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém um veículo por placa.
        /// </summary>
        [HttpGet("{placa}")]
        public IActionResult GetByPlaca(string placa)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Plate == placa);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Adiciona um novo veículo.
        /// </summary>
        [HttpPost]
        public IActionResult Post(VehicleCreateModel vehicle)
        {
            try
            {
                if (vehicle == null)
                {
                    return BadRequest("Dados do veículo inválidos.");
                }

                _context.Vehicles.Add(Vehicle.Parse(vehicle));
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetByPlaca), new { placa = vehicle.Plate }, vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove um veículo por placa.
        /// </summary>
        [HttpDelete("{placa}")]
        public IActionResult Delete(string placa)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Plate == placa);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }

                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza a disponibilidade de um veículo.
        /// </summary>
        [HttpPut("{placa}")]
        public IActionResult ChangeStatus(string placa, bool available)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Plate == placa);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }

                vehicle.Availability = available;
                _context.SaveChanges();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém a lista de veículos disponíveis para aluguel.
        /// </summary>
        [HttpGet("disponiveis")]
        public IActionResult GetAvailableVehicles()
        {
            try
            {
                var availableVehicles = _context.Vehicles.Where(v => v.Availability).ToList();
                return Ok(availableVehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém a lista de veículos atualmente alugados.
        /// </summary>
        [HttpGet("alugados")]
        public IActionResult GetRentedVehicles()
        {
            try
            {
                var rentedVehicles = _context.Vehicles.Where(v => !v.Availability && v!.InMaintenance).ToList();

                return Ok(rentedVehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém a lista de veículos em manutenção.
        /// </summary>
        [HttpGet("manutencao")]
        public IActionResult GetVehiclesInMaintenance()
        {
            try
            {
                var vehiclesInMaintenance = _context.Vehicles.Where(v => v.InMaintenance).ToList();
                return Ok(vehiclesInMaintenance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Registra um veículo em manutenção.
        /// </summary>
        [HttpPost("{placa}/manutencao")]
        public IActionResult RegisterVehicleMaintenance(string placa)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Plate == placa);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }

                vehicle.InMaintenance = true;
                vehicle.Availability = false;
                _context.SaveChanges();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Marca um veículo como pronto após a manutenção.
        /// </summary>
        [HttpPost("{placa}/sair-manutencao")]
        public IActionResult MarkVehicleReady(string placa)
        {
            try
            {
                var vehicle = _context.Vehicles.SingleOrDefault(v => v.Plate == placa);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }

                vehicle.InMaintenance = false;
                vehicle.Availability = true;
                _context.SaveChanges();

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost("finalizar-aluguel")]
        public IActionResult FinishRent(string plate)
        {
            try
            {
                // Encontra o veículo pelo número da placa
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.Plate == plate);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }

                // Verifica se o veículo está alugado
                var rental = _context.Rentals.FirstOrDefault(r => r.Vehicle.Plate == plate && r.EndDate == null);

                if (rental == null)
                {
                    return NotFound("Não há aluguel em andamento para este veículo.");
                }

                // Finaliza o aluguel definindo a data de término como a data atual
                rental.EndDate = DateTime.Now;
                _context.SaveChanges();

                return Ok("Aluguel finalizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost("{plate}/aluguel")]
        public IActionResult Rent(Guid clientId, [FromRoute] string plate)
        {
            try
            {
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.Plate == plate);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }

                var customer = _context.Customers.FirstOrDefault(v => v.ID == clientId);

                if (customer == null)
                {
                    return NotFound("Cliente não encontrado.");
                }

                Rental rent = new Rental { BeginDate = DateTime.Now, ClientID = clientId };

                _context.Rentals.Add(rent);

                ChangeStatus(plate, false);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
