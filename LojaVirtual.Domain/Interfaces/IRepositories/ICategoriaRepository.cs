using LojaVirtual.Domain.Models;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface ICategoriaRepository : IRepository<Categoria, int>
    {
    }
}