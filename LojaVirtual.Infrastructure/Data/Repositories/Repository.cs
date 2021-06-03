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
    public abstract class Repository<T, U> : IRepository<T, U>
        where U : struct
        where T : Entity<U>
    {
        protected const int _registrosPorPagina = 10;
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

        public virtual async Task<IPagedList<T>> ObterTodosPaginado(int? pagina)
        {
            var NumeroDaPagina = pagina ?? 1;
            return await _context.Set<T>().ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> ObterPorId(U id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> Encontrar(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task Remover(U id)
        {
            Task<T> entity = ObterPorId(id);
            _context.Remove(entity);
            await Salvar();
        }

        public virtual async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}