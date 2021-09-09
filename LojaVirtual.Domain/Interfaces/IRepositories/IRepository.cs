using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IRepository<T, U>
        where U : struct
        where T : Entity<U>
    {
        Task Adicionar(T entity);

        Task Atualizar(T entity);

        Task Remover(T entity);

        Task<T> ObterPorId(U id);

        Task<IEnumerable<T>> ObterTodos();

        Task<IPagedList<T>> ObterTodosPaginado(int? pagina);

        Task<IPagedList<T>> ObterTodosPaginado(int? pagina, string pesquisa);

        Task<IEnumerable<T>> Encontrar(Expression<Func<T, bool>> predicate);
    }
}