using LojaVirtual.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Infrastructure.Data.Context
{
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }

        public DbSet<Colaborador> Colaboradores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
    }
}