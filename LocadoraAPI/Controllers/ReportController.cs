using LocadoraAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAPI.Controllers
{
    /// <summary>
    /// Controller para gerenciar operações relacionadas a relatórios.
    /// </summary>
    [Route("api/relatorios")]
    public class ReportController : Controller
    {
        private readonly IRentalService _rentalService;

        /// <summary>
        /// Construtor do ReportController.
        /// </summary>
        /// <param name="rentalService">Serviço de aluguel utilizado para obter os dados dos relatórios.</param>
        public ReportController(IRentalService rentalService)
        {
            _rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
        }

        /// <summary>
        /// Obtém o relatório de vendas, incluindo receita total, aluguéis por categoria e aluguéis por período.
        /// </summary>
        [HttpGet("vendas")]
        public IActionResult GetSalesReport()
        {
            var rentals = _rentalService.GetAllRentals();

            decimal totalRevenue = rentals.Sum(r => r.Price);

            var rentalsByCategory = rentals
                .GroupBy(r => r.Vehicle.Category)
                .Select(group => new { Category = group.Key, Count = group.Count() });

            var rentalsByPeriod = rentals
                .GroupBy(r => r.BeginDate.Month)
                .Select(group => new { Month = group.Key, Count = group.Count() });

            var report = new
            {
                TotalRevenue = totalRevenue,
                RentalsByCategory = rentalsByCategory,
                RentalsByPeriod = rentalsByPeriod
            };

            return Ok(report);
        }

        /// <summary>
        /// Obtém as estatísticas, incluindo os veículos mais populares e a taxa de utilização.
        /// </summary>
        [HttpGet("estatisticas")]
        public IActionResult GetStatistics()
        {
            var rentals = _rentalService.GetAllRentals();

            var popularVehicles = rentals
                .GroupBy(r => r.Vehicle.Model)
                .Select(group => new { Model = group.Key, RentalsCount = group.Count() })
                .OrderByDescending(v => v.RentalsCount)
                .Take(5);

            var totalVehicles = _rentalService.GetTotalVehicles();
            decimal utilizationRate = (decimal)rentals.Count() / totalVehicles * 100;

            var statistics = new
            {
                PopularVehicles = popularVehicles,
                UtilizationRate = utilizationRate
            };

            return Ok(statistics);
        }
    }
}
