using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IRepository<T> where T : Entity
    {
        Task Adicionar(T entity);

        Task Atualizar(T entity);

        Task Remover(Guid id);

        Task<T> ObterPorId(Guid id);

        Task<IEnumerable<T>> ObterTodos();

        Task<IPagedList<T>> ObterTodosPaginado(int? pagina);

        Task<IEnumerable<T>> Encontrar(Expression<Func<T, bool>> predicate);
    }
}