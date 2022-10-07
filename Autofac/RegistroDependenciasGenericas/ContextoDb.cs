using Microsoft.EntityFrameworkCore;
using RegistroDependenciasGenericas.Configuracao;
using RegistroDependenciasGenericas.Model;

namespace RegistroDependenciasGenericas
{
    public class ContextoDb : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        public ContextoDb()
        {
        }

        public ContextoDb(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }
    }
}
