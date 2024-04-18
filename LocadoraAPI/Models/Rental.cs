using LocadoraAPI.Models.CreateModels;
using System;

namespace LocadoraAPI.Entities
{
    public class Rental
    {
        public Guid ID { get; set; }
        public Guid ClientID { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public Vehicle Vehicle { get; set; }

        public Rental()
        {
            ID = Guid.NewGuid(); 
        }

        public Rental(Guid clientId, DateTime beginDate, DateTime? endDate, decimal price, string status, Vehicle vehicle)
            : this() 
        {
            ClientID = clientId;
            BeginDate = beginDate;
            EndDate = endDate;
            Price = price;
            Status = status;
            Vehicle = vehicle;
        }

        public void Update(Vehicle vehicle, DateTime beginDate, DateTime? endDate, decimal price)
        {
            Vehicle = vehicle;
            BeginDate = beginDate;
            EndDate = endDate;
            Price = price;
        }

        internal static Rental Parse(RentalCreateModel rent)
        {

            Rental rental = new Rental
            {
                ClientID = rent.ClientId,
                BeginDate = rent.BeginDate,
                EndDate = rent.EndDate,
                Price = rent.Price,
                Status = rent.Status,
                Vehicle = new Vehicle { Plate = rent.VehiclePlate }
            };

            return rental;
        }
    }
}

