namespace LocadoraAPI.Models.CreateModels
{
    public class RentalCreateModel
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string VehiclePlate { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
