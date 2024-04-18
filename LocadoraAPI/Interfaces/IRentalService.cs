using LocadoraAPI.Entities;

namespace LocadoraAPI.Interfaces
{
    public interface IRentalService
    {

        public int GetTotalVehicles();

        public IEnumerable<Rental> GetAllRentals();
        
    }
}
