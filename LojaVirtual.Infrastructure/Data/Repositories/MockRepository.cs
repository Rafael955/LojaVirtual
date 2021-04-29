using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public abstract class MockRepository<T> : IRepository<T> where T : Entity
    {
        protected IList<T> _lista;

        protected MockRepository()
        {
            _lista = new List<T>();
        }

        public abstract Task Adicionar(T entity);

        public abstract Task Atualizar(T entity);

        public abstract Task Remover(Guid id);

        public virtual async Task<IReadOnlyCollection<T>> ObterTodos()
        {
            return await _lista.AsQueryable().ToListAsync();
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await _lista.AsQueryable().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IReadOnlyCollection<T>> Encontrar(Expression<Func<T, bool>> predicate)
        {
            return await _lista.AsQueryable().Where(predicate).ToListAsync();
        }
    }
}