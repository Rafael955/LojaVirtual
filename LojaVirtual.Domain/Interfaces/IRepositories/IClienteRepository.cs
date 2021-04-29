using LojaVirtual.Domain.Models;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> Login(string email, string senha);
    }
}