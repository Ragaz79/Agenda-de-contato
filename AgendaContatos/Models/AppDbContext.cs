using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>().HasData(
                    new Categoria { CategoriaId = "amigo", Nome = "Amigos"},
                    new Categoria { CategoriaId = "trabalho", Nome = "Trabalho" },
                    new Categoria { CategoriaId = "familia", Nome = "Familiares" },
                    new Categoria { CategoriaId = "serviço", Nome = "Serviços" }

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
