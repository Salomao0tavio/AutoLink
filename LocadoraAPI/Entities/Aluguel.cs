using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Entities
{
    public class Aluguel
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public decimal Preco { get; set; }

        public string Status { get; set; }

        public Veiculo Veiculo { get; set; }

       

        internal void Update(Veiculo veiculo, DateTime datainicio, DateTime datafim, decimal preco)
        {
            Veiculo = veiculo;
            DataInicio = datainicio;
            DataFim = datafim;
            Preco = preco;
        }
    }
}
