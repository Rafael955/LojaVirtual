using LojaVirtual.Domain.Models;
using System;
using System.Threading.Tasks;

namespace LojaVirtual.Domain.Interfaces.IRepositories
{
    public interface IImagemRepository : IRepository<Imagem, Guid>
    {
        Task ExcluirImagensDoProduto(int ProdutoId);
    }
}