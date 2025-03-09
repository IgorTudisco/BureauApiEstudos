using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
  public class BackendDbContext : DbContext
  {
    public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pesquisa> Pesquisas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Cliente>()
          .HasKey(c => c.Id);

      modelBuilder.Entity<Pesquisa>()
          .HasKey(p => p.Id);
    }
  }
}
