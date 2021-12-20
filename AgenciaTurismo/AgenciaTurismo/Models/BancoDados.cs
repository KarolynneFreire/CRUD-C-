using Microsoft.EntityFrameworkCore;

namespace AgenciaTurismo.Models
{
    public class BancoDados : DbContext

    {
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Promocao> Promocaos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<ClientDestino> ClientsDestinos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-3FOJOLI;Initial Catalog=BancoDados;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientDestino>(entity =>
            {
                entity.HasKey(e => new { e.ClienteId, e.DestinoId });
            });
        }
    }
}
