using ControleOrcamento.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleOrcamento.Banco {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Passivo> Passivos { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }

    }
}