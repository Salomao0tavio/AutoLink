using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Entities
{
    public class Rent
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public bool Status { get; set; }

        public Vehicle Vehicle { get; set; }

        internal void ChangeStatus(bool status)
        {
           Status = status;
        }

        internal void Update(Vehicle vehicle, DateTime startDate, DateTime endDate, decimal price)
        {
            Vehicle = vehicle;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Vehicle = vehicle;
        }
    }
}
