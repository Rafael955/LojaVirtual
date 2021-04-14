using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected LojaVirtualContext _context;

        protected Repository(LojaVirtualContext context)
        {
            _context = context;
        }

        public virtual async Task Adicionar(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Atualizar(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<T>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
