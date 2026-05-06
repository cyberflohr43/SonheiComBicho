namespace SonheiComBicho.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataCadastro { get; set; }

        public Jogador()
        {
            DataCadastro = DateTime.Now;
            Saldo = 0;
        }
    }
}
