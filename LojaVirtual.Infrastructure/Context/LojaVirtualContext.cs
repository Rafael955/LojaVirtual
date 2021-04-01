using LojaVirtual.Domain.Configs;
using LojaVirtual.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Infrastructure.Context
{
    public class LojaVirtualContext : DbContext
    {

        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
    }
}
