﻿using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente, Guid>, IClienteRepository
    {
        public LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public ClienteRepository(LojaVirtualContext context) : base(context)
        {
        }

        public async Task<Cliente> Login(string email, string senha)
        {
            return await _lojaContext.Clientes.Where(x => x.Email == email && x.Senha == senha).FirstOrDefaultAsync();
        }
    }
}