using LocadoraAPI.Entities;

public class RentDbContext 
{
   public List<Rent> Rents { get; set; }

    public RentDbContext()
    {
        Rents = new List<Rent>();
    }
}