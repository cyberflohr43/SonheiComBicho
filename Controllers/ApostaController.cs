using Microsoft.AspNetCore.Mvc;
using SonheiComBicho.Data;
using SonheiComBicho.Models;

namespace SonheiComBicho.Controllers
{
    public class ApostaController : Controller
    {
        private readonly AppDbContext _context;

        public ApostaController(AppDbContext context)
        {
            _context = context;
        }

        // Tela de fazer aposta
        public IActionResult Apostar(int jogadorId)
        {
            var jogador = _context.Jogadores.Find(jogadorId);
            if (jogador == null) return NotFound();

            ViewBag.Jogador = jogador;
            ViewBag.Bichos = Bicho.GetBichos();
            return View();
        }

        // Recebe a aposta e processa
        [HttpPost]
        public async Task<IActionResult> Apostar(int jogadorId, int bichoId, TipoAposta tipo, decimal valor)
        {
            var jogador = _context.Jogadores.Find(jogadorId);
            if (jogador == null) return NotFound();

            // Verifica se tem saldo suficiente
            if (valor <= 0 || valor > jogador.Saldo)
            {
                TempData["Erro"] = "Saldo insuficiente ou valor inválido!";
                return RedirectToAction("Apostar", new { jogadorId });
            }

            // Cria a aposta
            var aposta = new Aposta
            {
                JogadorId = jogadorId,
                BichoId = bichoId,
                Tipo = tipo,
                ValorApostado = valor
            };

            // Faz o sorteio
            var random = new Random();
            int numeroSorteado = random.Next(1, 101);
            var bichos = Bicho.GetBichos();
            var bichoSorteado = bichos.FirstOrDefault(b =>
                numeroSorteado >= b.NumeroInicial &&
                (b.NumeroFinal == 0 ? numeroSorteado == 100 : numeroSorteado <= b.NumeroFinal));

            // Verifica se ganhou
            aposta.Ganhou = bichoSorteado?.Id == bichoId;

            if (aposta.Ganhou == true)
            {
                aposta.ValorGanho = aposta.CalcularPremio();
                jogador.Saldo += aposta.ValorGanho;
            }
            else
            {
                jogador.Saldo -= valor;
            }

            _context.Apostas.Add(aposta);
            await _context.SaveChangesAsync();

            TempData["BichoSorteado"] = bichoSorteado?.Nome ?? "Desconhecido";
            TempData["Ganhou"] = aposta.Ganhou;
            TempData["ValorGanho"] = aposta.ValorGanho.ToString("F2");

            return RedirectToAction("Resultado", new { apostaId = aposta.Id });
        }

        // Tela de resultado
        public IActionResult Resultado(int apostaId)
        {
            var aposta = _context.Apostas.Find(apostaId);
            if (aposta == null) return NotFound();

            var jogador = _context.Jogadores.Find(aposta.JogadorId);
            var bichos = Bicho.GetBichos();
            var bicho = bichos.FirstOrDefault(b => b.Id == aposta.BichoId);

            ViewBag.Aposta = aposta;
            ViewBag.Jogador = jogador;
            ViewBag.BichoEscolhido = bicho?.Nome;
            ViewBag.BichoSorteado = TempData["BichoSorteado"];
            ViewBag.Ganhou = TempData["Ganhou"];
            ViewBag.ValorGanho = TempData["ValorGanho"];

            return View();
        }

        // Histórico de apostas do jogador
        public IActionResult Historico(int jogadorId)
        {
            var jogador = _context.Jogadores.Find(jogadorId);
            var apostas = _context.Apostas
                .Where(a => a.JogadorId == jogadorId)
                .OrderByDescending(a => a.DataAposta)
                .ToList();

            ViewBag.Jogador = jogador;
            return View(apostas);
        }
    }
}