namespace ConcessionariaAPI.Models
{
    public class Carro
    {
        public Carro(string nome, string marca, string categoria, string cor, int ano, double valor)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Marca = marca;
            Cor = cor;
            Categoria = categoria;
            Ano = ano;
            Valor = valor;
        }

        public string Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Cor {  get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public int Ano { get; set; }
        public double Valor { get; set; }
    }
}
