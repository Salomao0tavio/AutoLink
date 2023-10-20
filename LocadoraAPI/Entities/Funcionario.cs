namespace LocadoraAPI.Entities
{
    public class Funcionario
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cargo { get; set; }
            private string Email;
            private string? Telefone;
            public List<Aluguel>? Alugueis { get; set; }
        

    }
}
