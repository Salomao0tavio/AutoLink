using Models;

namespace Interfaces
{
    public interface IRentalService
    {

        public int GetTotalVehicles();

        public IEnumerable<Rental> GetAllRentals();

    }
}
