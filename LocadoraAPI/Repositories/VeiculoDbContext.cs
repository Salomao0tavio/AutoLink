using LocadoraAPI.Entities;

namespace LocadoraAPI.Repositories
{
    public class VeiculoDbContext
    {
        public List<Veiculo> Vehicles { get; set; }

        public VeiculoDbContext()
        {
            Vehicles = new List<Veiculo>();
        }
    }
}