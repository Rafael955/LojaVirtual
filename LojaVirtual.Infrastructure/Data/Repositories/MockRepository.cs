using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Infrastructure.Data.Repositories
{
    public abstract class MockRepository<T> : IRepository<T> where T : Entity
    {
        protected IList<T> _lista;

        protected MockRepository()
        {
            _lista = new List<T>();
        }

        public virtual async Task Adicionar(T entity)
        {
            await Task.Run(() =>
            {
                _lista.Add(entity);
            });
        }

        public virtual async Task Atualizar(T entity)
        {
            await Task.Run(() =>
            {
                _lista.Remove(entity);
                _lista.Add(entity);
            });
        }

        public virtual async Task Remover(Guid id)
        {
            await Task.Run(() =>
            {
                var entity = ObterPorId(id) as T;
                _lista.Remove(entity);
            });
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await _lista.AsQueryable().ToListAsync();
        }

        public virtual async Task<T> ObterPorId(Guid id)
        {
            return await _lista.AsQueryable().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> Encontrar(Expression<Func<T, bool>> predicate)
        {
            return await _lista.AsQueryable().Where(predicate).ToListAsync();
        }

        public Task<IPagedList<T>> ObterTodosPaginado(int? pagina)
        {
            throw new NotImplementedException();
        }
    }
}