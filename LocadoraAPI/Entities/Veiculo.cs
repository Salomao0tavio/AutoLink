using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Entities
{
    public class Veiculo
    {
        public string Placa { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public int Ano { get; set; }

        public List<Aluguel>? Alugueis = new List<Aluguel>(); 

        public bool Disponibilidade { get; set; }

        public string Categoria { get; set; }

        public Veiculo(string placa, string modelo, string marca, int ano) {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
        }    

        public void Update(string placa, string modelo, string marca, int ano) {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
        }  

        
    }
}
