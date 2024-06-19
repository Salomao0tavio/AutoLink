using Data;
using Models;
using Interfaces;

namespace Services
{
    public class RentalService : IRentalService
    {
        private readonly Context _context;

        public RentalService(Context context)
        {
            _context = context;
        }

        public IEnumerable<Rental> GetAllRentals()
        {
            return _context.Rentals;
        }

        public int GetTotalVehicles()
        {
            return _context.Vehicles.Count();
        }
    }
}
