using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using LojaVirtual.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContext _context;

        protected Repository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task Adicionar(T entity)
        {
            await _context.AddAsync(entity);
            await Salvar();
        }

        public virtual async Task Atualizar(T entity)
        {
            _context.Update(entity);
            await Salvar();
        }

        public virtual async Task<IReadOnlyCollection<T>> ObterTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task Remover(Guid id)
        {
            _context.Remove(id);
            await Salvar();
        }

        public virtual async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyCollection<T>> Encontrar(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
