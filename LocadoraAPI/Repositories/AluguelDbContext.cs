using LocadoraAPI.Entities;

public class AluguelDbContext 
{
   public List<Aluguel> Rents { get; set; }

    public AluguelDbContext()
    {
        Rents = new List<Aluguel>();
    }
}