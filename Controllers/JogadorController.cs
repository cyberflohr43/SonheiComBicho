using Microsoft.AspNetCore.Mvc;
using SonheiComBicho.Data;
using SonheiComBicho.Models;

namespace SonheiComBicho.Controllers
{
    public class JogadorController : Controller
    {
        private readonly AppDbContext _context;

        public JogadorController (AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _context.Jogadores.Add(jogador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jogador);
        }

        public async Task<IActionResult> Index()
        {
            var jogadores = _context.Jogadores.ToList();
            return View(jogadores);
        }

        public IActionResult Depositar(int id)
        {
            var jogador = _context.Jogadores.Find(id);
            if (jogador == null) return NotFound();
            return View(jogador);
        }

        [HttpPost]
        public async Task<IActionResult> Depositar(int id, decimal valor)
        {
            var jogador = _context.Jogadores.Find(id);
            if (jogador == null) return NotFound();

            if (valor > 0)
            {
                jogador.Saldo += valor;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}