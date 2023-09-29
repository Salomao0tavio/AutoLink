using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Entities
{
    public class Vehicle
    {
        public Guid Placa { get; set; }

        public string Modelo { get; set; }

        public string Marca { get; set; }

        public int Ano { get; set; }

        public List<Rent> Rents { get; set; }

        public Vehicle(Guid placa, string modelo, string marca, int ano) {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Rents = new List<Rent>();
        }    

 

        public void Update(Guid placa, string modelo, string marca, int ano) {
            Placa = placa;
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
            Rents = new List<Rent>();
        }  

        
    }
}
