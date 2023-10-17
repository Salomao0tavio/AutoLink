using LocadoraAPI.Entities;

namespace LocadoraAPI.Repositories
{
    public class VehicleDbContext
    {
        public List<Vehicle> Vehicles { get; set; }

        public VehicleDbContext()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}