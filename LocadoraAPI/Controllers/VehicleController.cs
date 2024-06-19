using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Data;
using Models;
using Models.CreateModels;

namespace Controllers
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
        /// <returns>Lista de veículos.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os veículos.")]
        [SwaggerResponse(200, "Lista de veículos obtida com sucesso.")]
        [SwaggerResponse(404, "Nenhum veículo encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult GetAll()
        {
            try
            {
                var vehicles = _context.Vehicles.ToList();

                if (vehicles.Any())
                {
                    return Ok(vehicles);
                }
                return NotFound("Nenhum veículo encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém um veículo por placa.
        /// </summary>
        /// <param name="placa">Placa do veículo.</param>
        /// <returns>Veículo encontrado.</returns>
        [HttpGet("{placa}")]
        [SwaggerOperation(Summary = "Obtém um veículo por placa.")]
        [SwaggerResponse(200, "Veículo obtido com sucesso.")]
        [SwaggerResponse(404, "Veículo não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="vehicle">Dados do veículo a ser adicionado.</param>
        /// <returns>Veículo criado.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo veículo.")]
        [SwaggerResponse(201, "Veículo criado com sucesso.")]
        [SwaggerResponse(400, "Dados do veículo inválidos.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="placa">Placa do veículo a ser removido.</param>
        /// <returns>Resposta de status.</returns>
        [HttpDelete("{placa}")]
        [SwaggerOperation(Summary = "Remove um veículo por placa.")]
        [SwaggerResponse(204, "Veículo removido com sucesso.")]
        [SwaggerResponse(404, "Veículo não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="placa">Placa do veículo.</param>
        /// <param name="available">Disponibilidade do veículo.</param>
        /// <returns>Veículo atualizado.</returns>
        [HttpPut("{placa}")]
        [SwaggerOperation(Summary = "Atualiza a disponibilidade de um veículo.")]
        [SwaggerResponse(200, "Veículo atualizado com sucesso.")]
        [SwaggerResponse(404, "Veículo não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <returns>Lista de veículos disponíveis.</returns>
        [HttpGet("disponiveis")]
        [SwaggerOperation(Summary = "Obtém a lista de veículos disponíveis para aluguel.")]
        [SwaggerResponse(200, "Lista de veículos disponíveis obtida com sucesso.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <returns>Lista de veículos alugados.</returns>
        [HttpGet("alugados")]
        [SwaggerOperation(Summary = "Obtém a lista de veículos atualmente alugados.")]
        [SwaggerResponse(200, "Lista de veículos alugados obtida com sucesso.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <returns>Lista de veículos em manutenção.</returns>
        [HttpGet("manutencao")]
        [SwaggerOperation(Summary = "Obtém a lista de veículos em manutenção.")]
        [SwaggerResponse(200, "Lista de veículos em manutenção obtida com sucesso.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="placa">Placa do veículo.</param>
        /// <returns>Veículo atualizado.</returns>
        [HttpPost("{placa}/manutencao")]
        [SwaggerOperation(Summary = "Registra um veículo em manutenção.")]
        [SwaggerResponse(200, "Veículo registrado em manutenção com sucesso.")]
        [SwaggerResponse(404, "Veículo não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
        /// <param name="placa">Placa do veículo.</param>
        /// <returns>Veículo atualizado.</returns>
        [HttpPost("{placa}/sair-manutencao")]
        [SwaggerOperation(Summary = "Marca um veículo como pronto após a manutenção.")]
        [SwaggerResponse(200, "Veículo marcado como pronto após manutenção com sucesso.")]
        [SwaggerResponse(404, "Veículo não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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

        /// <summary>
        /// Finaliza um aluguel de veículo.
        /// </summary>
        /// <param name="plate">Placa do veículo.</param>
        /// <returns>Resposta de status.</returns>
        [HttpPost("finalizar-aluguel")]
        [SwaggerOperation(Summary = "Finaliza um aluguel de veículo.")]
        [SwaggerResponse(200, "Aluguel finalizado com sucesso.")]
        [SwaggerResponse(404, "Veículo não encontrado ou nenhum aluguel em andamento para este veículo.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
        public IActionResult FinishRent(string plate)
        {
            try
            {
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.Plate == plate);

                if (vehicle == null)
                {
                    return NotFound("Veículo não encontrado.");
                }

                var rental = _context.Rentals.FirstOrDefault(r => r.Vehicle.Plate == plate && r.EndDate == null);

                if (rental == null)
                {
                    return NotFound("Não há aluguel em andamento para este veículo.");
                }

                rental.EndDate = DateTime.Now;
                _context.SaveChanges();

                return Ok("Aluguel finalizado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        /// <summary>
        /// Aluga um veículo para um cliente.
        /// </summary>
        /// <param name="clientId">ID do cliente.</param>
        /// <param name="plate">Placa do veículo.</param>
        /// <returns>Resposta de status.</returns>
        [HttpPost("{plate}/aluguel")]
        [SwaggerOperation(Summary = "Aluga um veículo para um cliente.")]
        [SwaggerResponse(200, "Veículo alugado com sucesso.")]
        [SwaggerResponse(404, "Veículo ou cliente não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor.")]
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
