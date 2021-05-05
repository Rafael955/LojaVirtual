using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public LojaVirtualContext _lojaContext
        {
            get { return _context as LojaVirtualContext; }
        }

        public ColaboradorRepository(DbContext context) : base(context)
        {
        }

        public async Task<Colaborador> Login(string email, string senha)
        {
            return await _lojaContext.Colaboradores.Where(x => x.Email == email && x.Senha == senha).FirstOrDefaultAsync();
        }
    }
}