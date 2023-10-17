using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Entities
{
    public class Vehicle
    {
        public string Placa { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public int Ano { get; set; }

        public List<Rent>? Rents { get; set; }

        public bool Disponibilidade { get; set; }

        public Vehicle(string placa, string modelo, string marca, int ano) {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Rents = new List<Rent>();
        }    

 

        public void Update(string placa, string modelo, string marca, int ano) {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Rents = new List<Rent>();
        }  

        
    }
}
