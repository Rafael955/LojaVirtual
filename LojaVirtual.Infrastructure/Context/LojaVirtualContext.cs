using LojaVirtual.Domain.Models;
using Microsoft.EntityFrameworkCore;
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
    }
}
