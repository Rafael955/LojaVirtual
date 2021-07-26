using LojaVirtual.Domain.Interfaces.IRepositories;
using LojaVirtual.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        protected readonly DbContext _context;
        protected int _registrosPorPagina;

        protected Repository(DbContext context, IConfiguration configuration)
        {
            _context = context;
            _registrosPorPagina = configuration.GetValue<int>("RegistrosPorPagina");
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
            return await _context.Set<T>().AsNoTracking().ToPagedListAsync(NumeroDaPagina, _registrosPorPagina);
        }

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> ObterPorId(U id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> Encontrar(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual async Task Remover(T entity)
        {
            _context.Remove(entity);
            await Salvar();
        }

        public virtual async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}