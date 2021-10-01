using LojaVirtual.Domain.Models;
using System.Collections.Generic;
using System.Text;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IProdutoRepository : IRepository<Produto, int>
    {
    }
}