using LocadoraAPI.Enums;

namespace LocadoraAPI.Models.CreateModels
{
    public class VehicleCreateModel
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public VehicleCategory Category { get; set; }
    }
}
