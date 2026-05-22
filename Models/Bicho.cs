namespace SonheiComBicho.Models
{
    public class Bicho
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NumeroInicial { get; set; }
        public int NumeroFinal { get; set; }

        // Os 25 bichos do jogo fixos
        public static List<Bicho> GetBichos()
        {
            return new List<Bicho>
            {
                new Bicho { Id = 1, Nome = "Avestruz", NumeroInicial = 1, NumeroFinal = 4 },
                new Bicho { Id = 2, Nome = "Águia", NumeroInicial = 5, NumeroFinal = 8 },
                new Bicho { Id = 3, Nome = "Burro", NumeroInicial = 9, NumeroFinal = 12 },
                new Bicho { Id = 4, Nome = "Borboleta", NumeroInicial = 13, NumeroFinal = 16 },
                new Bicho { Id = 5, Nome = "Cachorro", NumeroInicial = 17, NumeroFinal = 20 },
                new Bicho { Id = 6, Nome = "Cabra", NumeroInicial = 21, NumeroFinal = 24 },
                new Bicho { Id = 7, Nome = "Carneiro", NumeroInicial = 25, NumeroFinal = 28 },
                new Bicho { Id = 8, Nome = "Camelo", NumeroInicial = 29, NumeroFinal = 32 },
                new Bicho { Id = 9, Nome = "Cobra", NumeroInicial = 33, NumeroFinal = 36 },
                new Bicho { Id = 10, Nome = "Coelho", NumeroInicial = 37, NumeroFinal = 40 },
                new Bicho { Id = 11, Nome = "Cavalo", NumeroInicial = 41, NumeroFinal = 44 },
                new Bicho { Id = 12, Nome = "Elefante", NumeroInicial = 45, NumeroFinal = 48 },
                new Bicho { Id = 13, Nome = "Galo", NumeroInicial = 49, NumeroFinal = 52 },
                new Bicho { Id = 14, Nome = "Gato", NumeroInicial = 53, NumeroFinal = 56 },
                new Bicho { Id = 15, Nome = "Jacaré", NumeroInicial = 57, NumeroFinal = 60 },
                new Bicho { Id = 16, Nome = "Leão", NumeroInicial = 61, NumeroFinal = 64 },
                new Bicho { Id = 17, Nome = "Macaco", NumeroInicial = 65, NumeroFinal = 68 },
                new Bicho { Id = 18, Nome = "Porco", NumeroInicial = 69, NumeroFinal = 72 },
                new Bicho { Id = 19, Nome = "Pavão", NumeroInicial = 73, NumeroFinal = 76 },
                new Bicho { Id = 20, Nome = "Peru", NumeroInicial = 77, NumeroFinal = 80 },
                new Bicho { Id = 21, Nome = "Touro", NumeroInicial = 81, NumeroFinal = 84 },
                new Bicho { Id = 22, Nome = "Tigre", NumeroInicial = 85, NumeroFinal = 88 },
                new Bicho { Id = 23, Nome = "Urso", NumeroInicial = 89, NumeroFinal = 92 },
                new Bicho { Id = 24, Nome = "Veado", NumeroInicial = 93, NumeroFinal = 96 },
                new Bicho { Id = 25, Nome = "Vaca", NumeroInicial = 97, NumeroFinal = 0 }
            };
        }
    }
}
