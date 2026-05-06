using Microsoft.EntityFrameworkCore;
using SonheiComBicho.Models;

namespace SonheiComBicho.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Jogador> Jogadores { get; set; }
    }
}
