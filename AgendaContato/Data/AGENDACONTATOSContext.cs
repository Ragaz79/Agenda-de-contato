using AgendaContato.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace AgendaContato.Data
{
    public class AGENDACONTATOSContext : DbContext
    {
        public AGENDACONTATOSContext(DbContextOptions<AGENDACONTATOSContext> options) : base(options)
        {
        }
        public DbSet<TIPOCONTATO> TIPOCONTATOS { get; set; }
        public DbSet<CONTATO> CONTATOS { get; set; }
        public DbSet<GRUPOCONTATO> GRUPOCONTATOS { get; set; }
        public DbSet<CONTATOGRUPO> CONTATOSGRUPOS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-M7GU6EU;Database=AGENDACONTATOS;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    }
}
