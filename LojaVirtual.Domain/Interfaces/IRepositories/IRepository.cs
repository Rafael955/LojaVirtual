using LojaVirtual.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IRepository<T> where T : Entity
    {
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(Guid id);

        Task<IReadOnlyCollection<T>> Listar();
        Task ObterPorId(Guid id);
    }
}
