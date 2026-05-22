namespace SonheiComBicho.Models
{
    public enum TipoAposta
    {
        Bicho,
        Dezena,
        Centena,
        Milhar
    }

    public class Aposta
    {
        public int Id { get; set; }
        public int JogadorId { get; set; }
        public Jogador Jogador { get; set; }
        public int BichoId { get; set; }
        public TipoAposta Tipo { get; set; }
        public decimal ValorApostado { get; set; }
        public decimal ValorGanho { get; set; }
        public bool? Ganhou { get; set; }
        public DateTime DataAposta { get; set; }

        public Aposta()
        {
            DataAposta = DateTime.Now;
            Ganhou = null;
            ValorGanho = 0;
        }

        // Calcula o quanto o jogador ganha dependendo do tipo de aposta
        public decimal CalcularPremio()
        {
            return Tipo switch
            {
                TipoAposta.Bicho => ValorApostado * 18,
                TipoAposta.Dezena => ValorApostado * 60,
                TipoAposta.Centena => ValorApostado * 600,
                TipoAposta.Milhar => ValorApostado * 4000,
                _ => 0
            };
        }
    }
}