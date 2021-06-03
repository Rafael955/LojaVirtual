using LojaVirtual.Domain.Models;
using System;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IClienteRepository : IRepository<Cliente, Guid>
    {
        Task<Cliente> Login(string email, string senha);
    }
}