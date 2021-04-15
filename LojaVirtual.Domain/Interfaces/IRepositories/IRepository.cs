using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IRepository<T> where T : Entity
    {
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(Guid id);
        Task<T> ObterPorId(Guid id);
        Task<IReadOnlyCollection<T>> ObterTodos();
        Task<IReadOnlyCollection<T>> Encontrar(Expression<Func<T, bool>> predicate);
    }
}
